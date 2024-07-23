using AutoMapper;
using InsuranceConsultingOffice.Application.Bases;
using InsuranceConsultingOffice.Application.Dtos.Request;
using InsuranceConsultingOffice.Application.Dtos.Response;
using InsuranceConsultingOffice.Application.Interfaces;
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


            if (results is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<PolicyResponseDto>>(results);                                   // Mapear de Policy a PolicyResponseDto
                response.Message = ReplyMessage.MESSAGE_SUCCESS;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_NO_POLICIES_FOUND;
            }

            return response;

        }

        //public async Task<bool> RegisterPolicy(PolicyRequestDto requestDto)
        //{

        //}
    }
}
