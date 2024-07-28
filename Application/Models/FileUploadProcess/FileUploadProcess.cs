using AutoMapper.Configuration.Conventions;
using Azure;
using InsuranceConsultingOffice.Application.Bases;
using InsuranceConsultingOffice.Application.Dtos.Request;
using InsuranceConsultingOffice.Application.Interfaces;
using InsuranceConsultingOffice.Application.Validators;
using InsuranceConsultingOffice.Domain.Entities;
using InsuranceConsultingOffice.Infrastructure.Persistences.Repositories;
using InsuranceConsultingOffice.Infrastructure.Repository.DBContext;
using InsuranceConsultingOffice.Utilities;

namespace InsuranceConsultingOffice.Application.Models.FileUploadProcess
{
    public class FileUploadProcess : IFileUploadProcess
    {
        private readonly IInsuredsApplication _insuredsApplication;
        private readonly InsuranceDbContext _context;
        private readonly IFileUploadCodeAssign _codeAssignament;

        public FileUploadProcess(IInsuredsApplication insuredsApplication, InsuranceDbContext context, IFileUploadCodeAssign codeAssignament)
        {
            _insuredsApplication = insuredsApplication;
            _context = context;
            _codeAssignament = codeAssignament;
        }



        public BaseResponse<bool> UploadFile(IFormFile file)
        {
            _context.Database.BeginTransaction();

            try
            {
                var response = new BaseResponse<bool>();

                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    stream.Position = 0;

                    using (var reader = new StreamReader(stream))
                    {
                        string? line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            var columns = line.Split(',');
                            var columnsDataValidation = ColumsDataValidator.ColumnsDataValidor(columns);

                            if (columnsDataValidation.IsSuccess == false)
                            {
                                response.IsSuccess = false;
                                response.Message += columnsDataValidation.Message + Environment.NewLine;
                                continue;
                            }

                            var insuredDto = new InsuredRequestDto
                            {
                                IdCard = columns[0],
                                Name = columns[1],
                                Phone = columns[2],
                                Age = int.Parse(columns[3]),
                            };
                            Insured insured;
                            BaseResponse<bool> assignament;
                            var repository = new InsuredRepository(_context);

                            var insuredRegister = _insuredsApplication.RegisterInsured(insuredDto);
                            var insuredsList = repository.GetInsuredsByCardIdNoTrace(insuredDto.IdCard); 

                            if (insuredsList is null)
                            {
                                response.Message += insuredRegister.Message + ReplyMessage.MESSAGE_CLIENT_REGISTER_FATAL_ERROR + Environment.NewLine;
                                continue;
                            }

                            insured = repository.GetInsuredById(insuredsList.First().InsuredId);

                            if (insured.IdCard != insuredDto.IdCard || insured.Name != insuredDto.Name || insured.Phone != insuredDto.Phone || insured.Age != insuredDto.Age) 
                            {
                                response.Message += string.Format(ReplyMessage.MESSAGE_ANOTHER_CLIENT_HAS_THE_SAME_IDCARD, insured.IdCard) + Environment.NewLine;
                                continue;
                            }

                            assignament = _codeAssignament.AssignCodeToInsured(insured);

                            response.Message += string.Format(ReplyMessage.MESSAGE_CLIENT_CARDID, insured.IdCard) + insuredRegister.Message + assignament.Message + Environment.NewLine;
                        }
                    }
                }
                _context.Database.CommitTransaction();

                response.IsSuccess = true;
                response.Data = true;
                return response;
            }
            catch (Exception ex)
            {
                _context.Database.RollbackTransaction();

                Console.WriteLine(ex.Message.ToString());
                return new BaseResponse<bool>
                {
                    IsSuccess = false,
                    Data = false,
                    Message = ReplyMessage.MESSAGE_ERROR_TO_SAVE_IN_DB
                };
            }
        }
    }
}
