namespace InsuranceConsultingOffice.Domain.Entities;

public partial class Policy
{
    public int PolicyId { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public decimal InsuredAmount { get; set; }

    public decimal Premium { get; set; }

    //[JsonIgnore]
    public virtual ICollection<Assignament> Assignaments { get; set; } = new List<Assignament>();
}
