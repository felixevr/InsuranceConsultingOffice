using System;
using System.Collections.Generic;

namespace InsuranceConsultingOffice.Domain.Entities;

public partial class Insured
{
    public int InsuredId { get; set; }

    public string IdCard { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int Age { get; set; }

    public int? PolicyId { get; set; }

    public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

    public virtual Policy? Policy { get; set; }
}
