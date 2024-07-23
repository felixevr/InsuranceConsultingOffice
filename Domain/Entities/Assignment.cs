using System;
using System.Collections.Generic;

namespace InsuranceConsultingOffice.Domain.Entities;

public partial class Assignment
{
    public int AssignmentId { get; set; }

    public int? InsuredId { get; set; }

    public int? PolicyId { get; set; }

    public virtual Insured? Insured { get; set; }

    public virtual Policy? Policy { get; set; }
}
