using InsuranceConsultingOffice.Domain.Entities;

namespace InsuranceConsultingOffice.Application.Dtos.Response
{
    public class InsuredResponseDto
    {
        public int? InsuredId { get; set; }
        public string IdCard { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public int Age { get; set; }

        //public virtual Policy? Policy { get; set; }
        public virtual ICollection<PolicyAssignamentResponseDto>? PolicyAssignments { get; set; } = new List<PolicyAssignamentResponseDto>();
    }
}