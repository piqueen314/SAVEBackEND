using System;
using System.ComponentModel.DataAnnotations;

namespace SaveOrg.ViewModels
{
  public class Address
  {
    public int OwnerId { get; set; }

    public int AddressId { get; set; }

    public bool IsPrimary { get; set; }

    [Required]
    public string Address1 { get; set; }

    public string Address2 { get; set; }

    [Required]
    public string City { get; set; }

    [Required]
    public string State { get; set; }

    [Required]
    public int ZipCode { get; set; }

    [Required]
    public string ModUser { get; set; }

    public DateTime ModDate { get; set; }

    [Required]
    public string SetupUser { get; set; }

    public DateTime SetupDate { get; set; }
  }
}
