using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaveOrg.Models
{
  public class StudentEthnicity
  {
    public int StudentEthnicityId { get; set; }

    public int StudentId { get; set; }

    public int EthnicityId { get; set; }

    public bool IsSelected { get; set; }
  }
}
