namespace InsuranceConsultingOffice.Application.Dtos.Response
{
    public class PolicyResponseOnlyDto
    {
        public int PolicyId { get; set; }

        public string Name { get; set; } = null!;

        public string Code { get; set; } = null!;

        public decimal InsuredAmount { get; set; }

        public decimal Premium { get; set; }
    }
}
