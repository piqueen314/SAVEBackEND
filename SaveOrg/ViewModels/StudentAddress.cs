using System;
using System.ComponentModel.DataAnnotations;

namespace SaveOrg.ViewModels
{
  public class StudentAddress
  {
    public int StudentAddressId { get; set; }

    public int StudentId { get; set; }

    public int AddressId { get; set; }

    public bool IsPrimary { get; set; }

    [Required]
    public string ModUser { get; set; }

    public DateTime ModDate { get; set; }

    [Required]
    public string SetupUser { get; set; }

    public DateTime SetupDate { get; set; }

    public Address Address { get; set; }
  }
}
