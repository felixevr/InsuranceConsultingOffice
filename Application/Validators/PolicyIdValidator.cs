using InsuranceConsultingOffice.Application.Bases;
using InsuranceConsultingOffice.Application.Models.FileUploadProcess;
using InsuranceConsultingOffice.Domain.Entities;
using InsuranceConsultingOffice.Infrastructure.Persistences.Repositories;
using InsuranceConsultingOffice.Infrastructure.Repository.DBContext;
using InsuranceConsultingOffice.Utilities;
using Microsoft.EntityFrameworkCore;

namespace InsuranceConsultingOffice.Application.Validators
{
    public class PolicyIdValidator
    {
        private readonly InsuranceDbContext _context;
        public PolicyIdValidator(InsuranceDbContext context)
        {
            _context = context;
        }



        public BaseResponse<bool> PolicyIdFullValidation(int policyId)
        {
            var response = new BaseResponse<bool>();
            var repository = new PolicyRepository(_context);

            List<int> policyIds = repository.GetAllPoliciesIds();  

            if (policyIds.Contains(policyId) == false) 
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_CHECK_POLICY_CONFIGURATION;
            }
            else
            {
                response.IsSuccess = true;
            }
            return response;
        }
    }
}
