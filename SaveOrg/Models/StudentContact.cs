using SaveOrg.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SaveOrg.Models
{
  public class StudentContact : IChangeAudit
  {
    public int StudentContactId { get; set; }

    public int StudentId { get; set; }

    public int ContactId { get; set; }

    [Required]
    public string ModUser { get; set; }


    public DateTime ModDate { get; set; }

    [Required]
    public string SetupUser { get; set; }


    public DateTime SetupDate { get; set; }

    public virtual ICollection<StudentContactHistory> StudentContactHistories { get; set; }
  }
}