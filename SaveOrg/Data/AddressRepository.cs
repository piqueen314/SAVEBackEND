using SaveOrg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SaveOrg.Data
{
  public class AddressRepository
  {
    public Address GetAddress(int addressId)
    {
      var address = new Address();

      using (var db = new SaveDbContext())
      {
        address = db.Addresses.Single(x => x.AddressId == addressId);
      }

      return address;
    }
  }
}
