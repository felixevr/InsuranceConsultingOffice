namespace InsuranceConsultingOffice.Application.Dtos.Response
{
    public class InsuredAssignamentResponseDto
    {
        public int AssignmentId { get; set; }
        public int? InsuredId { get; set; }
        public int? PolicyId { get; set; }

        public virtual InsuredResponseOnlyDto? Insured { get; set; }
    }
}

//Antiguo AssignamentRequestDto