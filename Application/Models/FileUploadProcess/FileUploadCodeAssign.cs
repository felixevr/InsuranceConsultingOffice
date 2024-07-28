using InsuranceConsultingOffice.Application.Bases;
using InsuranceConsultingOffice.Application.Interfaces;
using InsuranceConsultingOffice.Domain.Entities;
using InsuranceConsultingOffice.Infrastructure.Persistences.Repositories;
using InsuranceConsultingOffice.Infrastructure.Repository.DBContext;
using InsuranceConsultingOffice.Utilities;

namespace InsuranceConsultingOffice.Application.Models.FileUploadProcess
{
    public class FileUploadCodeAssign : IFileUploadCodeAssign
    {
        private readonly InsuranceDbContext _context;   // Pendiente con este context aquí
        public FileUploadCodeAssign(InsuranceDbContext context)
        {
            _context = context;
        }



        public BaseResponse<bool> AssignCodeToInsured(Insured insured)
        {
            var response = new BaseResponse<bool>();
            var repository = new AssignamentRepository(_context);

            if (insured.Age > 0 && insured.Age <= 17) 
            {
                return repository.RegisterAssignament(insured, (int)FileUploadProcessConfigurationPolicyAssignament.EDAD_DE_0_A_17);                
            }

            if (insured.Age >= 18 && insured.Age <= 30)
            {
                return repository.RegisterAssignament(insured, (int)FileUploadProcessConfigurationPolicyAssignament.EDAD_DE_18_A_30);                
            }

            if (insured.Age >= 31 && insured.Age <= 45)
            {
                return repository.RegisterAssignament(insured, (int)FileUploadProcessConfigurationPolicyAssignament.EDAD_DE_31_A_45);                
            }
            
            if (insured.Age >= 46 && insured.Age <= 60)
            {
                return repository.RegisterAssignament(insured, (int)FileUploadProcessConfigurationPolicyAssignament.EDAD_DE_46_A_60);                
            }

            if (insured.Age >= 61 && insured.Age <= 120)
            {
                return repository.RegisterAssignament(insured, (int)FileUploadProcessConfigurationPolicyAssignament.EDAD_DE_61_A_120);                
            }

            response.IsSuccess = false;
            response.Message = string.Format(ReplyMessage.MESSAGE_CLIENT_AGE_OUT_OF_RANGE, insured.IdCard);
            return response;
        }
    }
}
