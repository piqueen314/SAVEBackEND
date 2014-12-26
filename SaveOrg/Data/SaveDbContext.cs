using Microsoft.AspNet.Identity.EntityFramework;
using SaveOrg.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SaveOrg.Data
{
  public class SaveDbContext : IdentityDbContext<ApplicationUser>
  {
    public SaveDbContext() : base("name=SaveDbConnection")
    {

    }

    public static SaveDbContext Create()
    {
      return new SaveDbContext();
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<StudentHistory> StudentHistories { get; set; }
    public DbSet<Address> Addresses { get; set; }
  }
}
