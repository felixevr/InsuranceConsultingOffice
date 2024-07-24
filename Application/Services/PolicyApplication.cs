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
            var policies = new PolicyRepository();
            var results = policies.GetPoliciesByCode(_context, code);

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
            var validation = GetPoliciesByCode(requestDto.Code);

            if (validation.Data.Count() > 0)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_ALREADY_EXIST;
            
                return response;
            }

            var policy = _mapper.Map<Policy>(requestDto);
            _context.Add(policy);
            var recordsAffected = _context.SaveChanges();

            if (recordsAffected >0 )
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_SUCCESS_TO_REGISTER;
                response.Data = recordsAffected > 0 ;
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
            var policy = new PolicyRepository();

            var policyById = policy.GetPolicyById(_context, id);

            if (policyById is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_CODE_DOES_NOT_EXIST;

                return response;
            }

            var policyNew = _mapper.Map<Policy>(requestDto);
            policyNew.PolicyId = id;

            _context.Update(policyNew);
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

        public BaseResponse<bool> RemovePolicy(int id) 
        { 
            var response = new BaseResponse<bool>();
            var policy = new PolicyRepository();

            var policyById = policy.GetPolicyById(_context, id);

            if (policyById is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_ERROR_TO_DELETE;

                return response;
            }

            _context.Remove(policyById);
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
