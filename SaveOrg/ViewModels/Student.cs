using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SaveOrg.ViewModels
{
  public class Student
  {
    [DisplayName("Student ID")]
    public int StudentId { get; set; }

    [Required]
    [DisplayName("First Name")]
    public string FirstName { get; set; }

    [Required]
    [DisplayName("Last Name")]
    public string LastName { get; set; }

    [DisplayName("Gender")]
    public int GenderFlag { get; set; }

    public IEnumerable<SelectListItem> GenderList { get; set; }

    [DisplayName("Date of Birth")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
    public DateTime DateOfBirth { get; set; }

    [Required]
    [DisplayName("Mod User")]
    public string ModUser { get; set; }

    [DisplayName("Mod Date")]
    public DateTime ModDate { get; set; }

    [Required]
    [DisplayName("Setup User")]
    public string SetupUser { get; set; }

    [DisplayName("Setup Date")]
    public DateTime SetupDate { get; set; }

    public List<StudentAddress> StudentAddresses { get; set; }

    public int Age
    {
      get
      {
        //return the age based on DateTime.Now - DateOfBirth
        //age = today's year minus DOB year
        var curDate = DateTime.Now;

        var age = curDate.Year - DateOfBirth.Year;

        //if DOB > curDate minus age (years), then decrement age by 1
        //because it's not your birthday yet
        age = (DateOfBirth > curDate.AddYears(-age)) ? age-- : age;

        return age;
      }
    }
  }
}