namespace InsuranceConsultingOffice.Application.Dtos.Response
{
    public class InsuredResponseOnlyDto
    {
        public int? InsuredId { get; set; }
        public string IdCard { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public int Age { get; set; }
    }
}
