using System;
using System.ComponentModel.DataAnnotations;

namespace SaveOrg.Models
{
  public class StudentParentHistory
  {
    public int StudentParentHistoryId { get; set; }

    public int StudentParentId { get; set; }

    public int StudentId { get; set; }

    public int ParentId { get; set; }

    [Required]
    public string ModUser { get; set; }


    public DateTime ModDate { get; set; }

    [Required]
    public string SetupUser { get; set; }


    public DateTime SetupDate { get; set; }
  }
}
