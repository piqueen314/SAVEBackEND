using SaveOrg.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace SaveOrg.Models
{
  public class ParentHistory : IChangeAudit
  {
    public int ParentHistoryId { get; set; }

    public int ParentId { get; set; }

    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string ModUser { get; set; }

    public DateTime ModDate { get; set; }
    [Required]
    public string SetupUser { get; set; }

    public DateTime SetupDate { get; set; }
  }
}
