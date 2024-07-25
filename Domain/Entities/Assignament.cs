namespace InsuranceConsultingOffice.Domain.Entities;

public partial class Assignament
{
    public int AssignmentId { get; set; }

    public int? InsuredId { get; set; }

    public int? PolicyId { get; set; }
    //[JsonIgnore]
    public virtual Insured? Insured { get; set; }
    //[JsonIgnore]
    public virtual Policy? Policy { get; set; }
}
