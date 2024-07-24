using InsuranceConsultingOffice.Domain.Entities;

namespace InsuranceConsultingOffice.Application.Dtos.Response
{
    public class PolicyResponseDto
    {
        public string? PolicyId { get; set; }

        public string Name { get; set; } = null!;

        public string Code { get; set; } = null!;

        public decimal InsuredAmount { get; set; }

        public decimal Premium { get; set; }

        public virtual ICollection<AssignamentResponseDto> Assignments { get; set; } = new List<AssignamentResponseDto>();
    }
}