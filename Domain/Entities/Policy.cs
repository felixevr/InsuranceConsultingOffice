namespace InsuranceConsultingOffice.Domain.Entities;

public partial class Policy
{
    public int PolicyId { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public decimal InsuredAmount { get; set; }

    public decimal Premium { get; set; }

    public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

    public virtual ICollection<Insured> Insureds { get; set; } = new List<Insured>();
}
