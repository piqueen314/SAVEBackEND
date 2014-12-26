using SaveOrg.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace SaveOrg.Models
{
  public class StudentAddressHistory : IChangeAudit
  {
    public int StudentAddressHistoryId { get; set; }

    public int StudentAddressId { get; set; }

    public int StudentId { get; set; }

    public int AddressId { get; set; }

    [Required]
    public string ModUser { get; set; }


    public DateTime ModDate { get; set; }

    [Required]
    public string SetupUser { get; set; }


    public DateTime SetupDate { get; set; }
  }
}
