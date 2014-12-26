using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SaveOrg.Utilities
{
  public static class Lookups
  {
    public enum EthnicityTypes
    {
      African = 1,
      AfricanAmerican = 2,
      Asian = 3,
      Caucasian = 4,
      Hispanic = 5
    }

    public enum Gender
    {
      Female = 1,
      Male = 2,
      Other = 3
    }

    public static IEnumerable<SelectListItem> GetGenderList()
    {
      var genderList = new List<SelectListItem>();

      foreach(Gender gen in (Gender[])Enum.GetValues(typeof(Gender)))
      {
        genderList.Add(new SelectListItem { Text = gen.ToString(), Value = ((int)gen).ToString() });
      }

      return genderList.AsEnumerable();
    }
  }
}