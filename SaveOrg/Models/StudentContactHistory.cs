using SaveOrg.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace SaveOrg.Models
{
  public class StudentContactHistory : IChangeAudit
  {
    public int StudentContactHistoryId { get; set; }

    public int StudentContactId { get; set; }

    public int StudentId { get; set; }

    public int ContactId { get; set; }

    [Required]
    public string ModUser { get; set; }


    public DateTime ModDate { get; set; }

    [Required]
    public string SetupUser { get; set; }


    public DateTime SetupDate { get; set; }

  }
}