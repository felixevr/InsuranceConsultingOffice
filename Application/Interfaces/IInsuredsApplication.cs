using InsuranceConsultingOffice.Application.Bases;
using InsuranceConsultingOffice.Application.Dtos.Request;
using InsuranceConsultingOffice.Application.Dtos.Response;

namespace InsuranceConsultingOffice.Application.Interfaces
{
    public interface IInsuredsApplication
    {
        BaseResponse<IEnumerable<InsuredResponseDto>> GetInsuredsByCardId(string cardId);
        BaseResponse<bool> RegisterInsured(InsuredRequestDto requestDto);
        BaseResponse<bool> EditInsured(InsuredRequestDto requestDto, int id);
        BaseResponse<bool> RemoveInsured(int id);
    }
}