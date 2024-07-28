using InsuranceConsultingOffice.Application.Bases;
using InsuranceConsultingOffice.Domain.Entities;

namespace InsuranceConsultingOffice.Application.Models.FileUploadProcess
{
    public interface IFileUploadCodeAssign
    {
        BaseResponse<bool> AssignCodeToInsured(Insured insured);
    }
}
