using InsuranceConsultingOffice.Application.Bases;
using InsuranceConsultingOffice.Application.Dtos.Response;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceConsultingOffice.Application.Interfaces
{
    public interface IPolicyApplication
    {
        BaseResponse<IEnumerable<PolicyResponseDto>> GetPoliciesByCode(string code);
    }
}