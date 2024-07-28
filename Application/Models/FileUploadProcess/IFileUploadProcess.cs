using InsuranceConsultingOffice.Application.Bases;

namespace InsuranceConsultingOffice.Application.Models.FileUploadProcess
{
    public interface IFileUploadProcess
    {
        BaseResponse<bool> UploadFile(IFormFile file);
    }
}
