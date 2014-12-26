using SaveOrg.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace SaveOrg.Models 
{
  public class Contact : IChangeAudit
  {
    public int ContactId {get; set;}

    public int ContactTypeId { get; set; }

    [Required]
    public string Value { get; set; }

    public bool IsPrimary { get; set; }

    [Required]
    public string ModUser { get; set; }

    public DateTime ModDate { get; set; }
    [Required]
    public string SetupUser { get; set; }
  
    public DateTime SetupDate { get; set; }

    public virtual ContactType ContactType { get; set; }
  }
}
