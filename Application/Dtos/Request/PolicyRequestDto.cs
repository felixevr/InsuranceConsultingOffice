namespace InsuranceConsultingOffice.Application.Dtos.Request
{
    public class PolicyRequestDto
    {
        public string? Name { get; set; } 

        public string? Code { get; set; } 

        public decimal InsuredAmount { get; set; }

        public decimal Premium { get; set; }
    }
}
