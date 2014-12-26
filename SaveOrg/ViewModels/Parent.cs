using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SaveOrg.ViewModels
{
  public class Parent
  {

    public int ParentId { get; set; }

    public int AddressId { get; set; }

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

    public List<Student> Student { get; set; }
  }
}
