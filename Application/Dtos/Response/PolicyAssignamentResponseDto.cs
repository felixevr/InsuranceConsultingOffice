namespace InsuranceConsultingOffice.Application.Dtos.Response
{
    public class PolicyAssignamentResponseDto
    {
        public int AssignmentId { get; set; }
        public int? InsuredId { get; set; }
        public int? PolicyId { get; set; }

        public virtual PolicyResponseOnlyDto? Policy { get; set; }
    }
}