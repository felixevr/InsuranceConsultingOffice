using InsuranceConsultingOffice.Application.Bases;
using InsuranceConsultingOffice.Application.Dtos.Request;
using InsuranceConsultingOffice.Application.Dtos.Response;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceConsultingOffice.Application.Interfaces
{
    public interface IPolicyApplication
    {
        BaseResponse<IEnumerable<PolicyResponseDto>> GetPoliciesByCode(string code);
        BaseResponse<bool> RegisterPolicy(PolicyRequestDto requestDto);
        BaseResponse<bool> EditPolicy(int id, PolicyRequestDto requestDto);
        BaseResponse<bool> RemovePolicy(int id);
    }
}