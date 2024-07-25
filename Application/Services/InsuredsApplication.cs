using AutoMapper;
using InsuranceConsultingOffice.Application.Bases;
using InsuranceConsultingOffice.Application.Dtos.Request;
using InsuranceConsultingOffice.Application.Dtos.Response;
using InsuranceConsultingOffice.Application.Interfaces;
using InsuranceConsultingOffice.Domain.Entities;
using InsuranceConsultingOffice.Infrastructure.Persistences.Repositories;
using InsuranceConsultingOffice.Infrastructure.Repository.DBContext;
using InsuranceConsultingOffice.Utilities;
using NuGet.Protocol.Core.Types;

namespace InsuranceConsultingOffice.Application.Services
{
    public class InsuredsApplication : IInsuredsApplication
    {
        public readonly InsuranceDbContext _context;
        public readonly IMapper _mapper;

        public InsuredsApplication(InsuranceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public BaseResponse<IEnumerable<InsuredResponseDto>> GetInsuredsByCardId(string cardId)
        {
            var response = new BaseResponse<IEnumerable<InsuredResponseDto>>();
            var repository = new InsuredRepository();

            IEnumerable<Insured> insureds = repository.GetInsuredsByCardId(_context, cardId);

            if (insureds.Any())
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<InsuredResponseDto>>(insureds);
                response.Message = ReplyMessage.MESSAGE_SUCCESS;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_INSURED_DOES_NOT_EXIST;
            }
            return response;
        }



        public BaseResponse<bool> RegisterInsured(InsuredRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();

            var cardIdValidation = GetInsuredsByCardId(requestDto.IdCard);

            if (cardIdValidation.Data is not null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_CLIENT_ALREADY_EXIST;

                return response;
            }

            Insured insured = _mapper.Map<Insured>(requestDto);
            _context.Add(insured);
            var recordsAffected = _context.SaveChanges();

            if (recordsAffected > 0)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_SUCCESS_TO_REGISTER;
                response.Data = recordsAffected > 0;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_ERROR_TO_SAVE_IN_DB;
            }
            return response;
        }



        public BaseResponse<bool> EditInsured(InsuredRequestDto requestDto, int id)
        {
            var response = new BaseResponse<bool>();
            var repository = new InsuredRepository();

            IEnumerable<Insured> insureds = repository.GetInsuredsByCardId(_context, requestDto.IdCard);

            if (insureds.Any())
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_IDCARD_NUMBER_ALREADY_ASSIGNED;

                return response;
            }

            Insured insured = repository.GetInsuredById(_context, id);

            if (insured is null || insureds.First().IdCard != requestDto.IdCard)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_CLIENT_ID_DOES_NOT_EXIST;

                return response;
            }

            insured = _mapper.Map<Insured>(requestDto);
            insured.InsuredId = id;

            _context.Update(insured);
            var recordsAffected = _context.SaveChanges();

            if (recordsAffected > 0)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_SUCCESS;
                response.Data = recordsAffected > 0;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_ERROR_TO_SAVE_IN_DB;
            }

            return response;
        }



        public BaseResponse<bool> RemoveInsured(int id)
        {
            var response = new BaseResponse<bool>();
            var repository = new InsuredRepository();

            var insured = repository.GetInsuredById(_context, id);

            if (insured is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_ERROR_TO_DELETE;

                return response;
            }

            _context.Remove(insured);
            var recordsAffected = _context.SaveChanges();

            if (recordsAffected > 0)
            {
                response.IsSuccess = true;
                response.Data = recordsAffected > 0;
                response.Message = ReplyMessage.MESSAGE_SUCCESS;
            }

            return response;
        }
    }
}
