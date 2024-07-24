namespace InsuranceConsultingOffice.Domain.Entities;

public partial class Insured
{
    public int InsuredId { get; set; }

    public string IdCard { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int Age { get; set; }

    //[JsonIgnore]
    public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
}
