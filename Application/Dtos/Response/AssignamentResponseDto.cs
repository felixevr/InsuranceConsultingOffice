namespace InsuranceConsultingOffice.Application.Dtos.Response
{
    public class AssignamentResponseDto
    {
        public int AssignmentId { get; set; }
        public int? InsuredId { get; set; }
        public int? PolicyId { get; set; }

        public virtual InsuredResponseDto? Insured { get; set; }
    }
}