using SaveOrg.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaveOrg.Models
{
  public class Student: IChangeAudit
  {
    public int StudentId { get; set; }
    
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }

    public int GenderFlag { get; set; }

    public DateTime DateOfBirth { get; set; }

    public DateTime? InactiveDate { get; set; }

    [Required]
    public string ModUser { get; set; }

    public DateTime ModDate { get; set; }
    
    [Required]
    public string SetupUser { get; set; }

    public DateTime SetupDate { get; set; }

    public virtual ICollection<StudentAddress> StudentAddresses { get; set; }

    public virtual ICollection<StudentHistory> StudentHistories { get; set; }
  }
}

