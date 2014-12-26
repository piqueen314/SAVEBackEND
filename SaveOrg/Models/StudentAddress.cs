using SaveOrg.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SaveOrg.Models
{
  public class StudentAddress: IChangeAudit
  {
    public int StudentAddressId { get; set; }

    public int StudentId { get; set; }

    public int AddressId { get; set; }

    [Required]
    public string ModUser { get; set; }

    public DateTime ModDate { get; set; }
    
    [Required]
    public string SetupUser { get; set; }

    public DateTime SetupDate { get; set; }

    public virtual Address Address { get; set; }

    public virtual ICollection<StudentAddressHistory> StudentAddressHistories { get; set; }
  }
}
