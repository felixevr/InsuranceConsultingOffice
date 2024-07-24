using InsuranceConsultingOffice.Domain.Entities;

namespace InsuranceConsultingOffice.Application.Dtos.Response
{
    public class InsuredResponseDto
    {
        public string IdCard { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public int Age { get; set; }

        public virtual Policy? Policy { get; set; }
    }
}