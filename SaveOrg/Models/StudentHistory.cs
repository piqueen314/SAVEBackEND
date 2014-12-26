using SaveOrg.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace SaveOrg.Models
{
  public class StudentHistory : IChangeAudit

  {
    public int StudentHistoryId { get; set; }

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

  }
}