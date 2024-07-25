namespace InsuranceConsultingOffice.Application.Dtos.Request
{
    public class InsuredRequestDto
    {
        public string IdCard { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public int Age { get; set; }
    }
}