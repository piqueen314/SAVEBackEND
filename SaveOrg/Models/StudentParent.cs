using System.Web.Profile;
using SaveOrg.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SaveOrg.Models
{
  public class StudentParent : IChangeAudit
  {
    public int StudentParentId { get; set; }

    public int StudentId { get; set; }

    public int ParentId { get; set; }

    [Required]
    public string ModUser { get; set; }


    public DateTime ModDate { get; set; }

    [Required]
    public string SetupUser { get; set; }


    public DateTime SetupDate { get; set; }

    public virtual ICollection<StudentParentHistory> StudentParentHistories { get; set; }
    public virtual Parent Parent { get; set; }
    
  }
}
