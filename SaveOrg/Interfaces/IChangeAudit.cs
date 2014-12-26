using System;
using System.ComponentModel.DataAnnotations;

namespace SaveOrg.Interfaces
{
  public interface IChangeAudit
  {
    [Required]
    string ModUser { get; set; }

    DateTime ModDate { get; set; }
    
    [Required]
    string SetupUser { get; set; }

    DateTime SetupDate { get; set; }
  }
}
