using InsuranceConsultingOffice.Application.Bases;
using InsuranceConsultingOffice.Application.Validators;
using InsuranceConsultingOffice.Domain.Entities;
using InsuranceConsultingOffice.Infrastructure.Repository.DBContext;
using InsuranceConsultingOffice.Utilities;

namespace InsuranceConsultingOffice.Infrastructure.Persistences.Repositories
{
    public class AssignamentRepository
    {
        private readonly InsuranceDbContext _context;

        public AssignamentRepository(InsuranceDbContext context)
        {
            _context = context;
        }



        public BaseResponse<bool> RegisterAssignament(Insured insured, int policyId) 
        {
            var response = new BaseResponse<bool>();
            var policyIdValidator = new PolicyIdValidator(_context);

            bool assignamentValidation = AssignamentExists(insured.InsuredId, policyId);

            if (assignamentValidation)
            {
                response.IsSuccess = false;
                response.Message = string.Format(ReplyMessage.MESSAGE_CLIENT_ALREADY_HAS_ASSIGNAMENT, policyId);
                return response;
            }

            var policyIdValidation = policyIdValidator.PolicyIdFullValidation(policyId);

            if (!policyIdValidation.IsSuccess)
            {
                response.IsSuccess = false;
                response.Message = policyIdValidation.Message;
                return response;
            }

            var assignament = new Assignament()
            {
                InsuredId = insured.InsuredId,
                PolicyId = policyId
            };

            _context.Add(assignament);
            var recordsAffected = _context.SaveChanges(); // Data Reader Error. -- CORREGIDO!!!

            if (recordsAffected > 0)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_CODE_WAS_ASSIGNED;
                response.Data = recordsAffected > 0;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_ERROR_TO_SAVE_IN_DB;
            }

            return response;

        }



        private bool AssignamentExists(int insuredId, int policyId)
        {
            return _context.Assignments.Any(a => a.InsuredId == insuredId && a.PolicyId == policyId);
        }
    }
}