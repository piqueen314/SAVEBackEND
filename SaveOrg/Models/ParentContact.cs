using SaveOrg.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SaveOrg.Models
{
  public class ParentContact : IChangeAudit
  {
    public int ParentContactId { get; set; }

    public int ParentId { get; set; }

    public int ContactId { get; set; }

    [Required]
    public string ModUser { get; set; }


    public DateTime ModDate { get; set; }

    [Required]
    public string SetupUser { get; set; }


    public DateTime SetupDate { get; set; }

    public virtual ICollection<ParentContactHistory> ParentContactHistories { get; set; }

  }
}
