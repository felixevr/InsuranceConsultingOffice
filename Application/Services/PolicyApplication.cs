using AutoMapper;
using InsuranceConsultingOffice.Application.Bases;
using InsuranceConsultingOffice.Application.Dtos.Request;
using InsuranceConsultingOffice.Application.Dtos.Response;
using InsuranceConsultingOffice.Application.Interfaces;
using InsuranceConsultingOffice.Domain.Entities;
using InsuranceConsultingOffice.Infrastructure.Persistences.Repositories;
using InsuranceConsultingOffice.Infrastructure.Repository.DBContext;
using InsuranceConsultingOffice.Utilities;

namespace InsuranceConsultingOffice.Application.Services
{
    public class PolicyApplication : IPolicyApplication
    {
        private readonly InsuranceDbContext _context;
        private readonly IMapper _mapper;

        public PolicyApplication(InsuranceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public BaseResponse<IEnumerable<PolicyResponseDto>> GetPoliciesByCode(string code)
        {
            var response = new BaseResponse<IEnumerable<PolicyResponseDto>>();
            var repository = new PolicyRepository();

            IEnumerable<Policy> results = repository.GetPoliciesByCode(_context, code);

            if (results.Count() > 0)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<PolicyResponseDto>>(results);
                response.Message = ReplyMessage.MESSAGE_SUCCESS;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_NO_POLICIES_FOUND;
            }

            return response;

        }



        public BaseResponse<bool> RegisterPolicy(PolicyRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();

            var codeValidation = GetPoliciesByCode(requestDto.Code!);

            if (codeValidation.Data is not null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_INSURANCE_ALREADY_EXIST;
            
                return response;
            }

            Policy policy = _mapper.Map<Policy>(requestDto);
            _context.Add(policy);
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



        public BaseResponse<bool> EditPolicy(int id, PolicyRequestDto requestDto) 
        {
            var response = new BaseResponse<bool>();
            var repository = new PolicyRepository();

            IEnumerable<Policy> policies = repository.GetPoliciesByCode(_context, requestDto.Code!);  // ESTO AGREGA UNA ENTIDAD AL TRACKER
            Policy policy = repository.GetPolicyById(_context, id);

            if (policy is null) // No Existe el Id 
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_INSURANCE_ID_DOES_NOT_EXIST;

                return response;
            }

            var firstPolicy = policies.FirstOrDefault(); 


            if (firstPolicy is not null)
            {
                if (firstPolicy.PolicyId != policy.PolicyId) 
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_INSURANCE_CODE_ALREADY_ASSIGNED;

                    return response;
                }

                policy = _mapper.Map<Policy>(requestDto);
                policy.PolicyId = id;

                _context.Update(policy);
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
            }
            
            return response;
        }



        public BaseResponse<bool> RemovePolicy(int id) 
        { 
            var response = new BaseResponse<bool>();
            var repository = new PolicyRepository();

            var policy = repository.GetPolicyById(_context, id);

            if (policy is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_ERROR_TO_DELETE;

                return response;
            }

            _context.Remove(policy);
            var recordsAffected = _context.SaveChanges();

            if (recordsAffected > 0)
            {
                response.IsSuccess = true;
                response.Data= recordsAffected > 0;
                response.Message = ReplyMessage.MESSAGE_SUCCESS;
            }

            return response;
        }
    }
}
