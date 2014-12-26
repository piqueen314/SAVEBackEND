using SaveOrg.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using viewModels = SaveOrg.ViewModels;
using dataModels = SaveOrg.Models;
using AutoMapper;

namespace SaveOrg.Controllers
{
  public class AddressController : Controller
  {
    [HttpGet]
    public PartialViewResult GetAddressEditor(int? addressId, int ownerId)
    {
      var repo = new AddressRepository();
      var addressModel = new viewModels.Address();

      if (addressId.HasValue)
      {
        addressModel = Mapper.Map<dataModels.Address, viewModels.Address>(repo.GetAddress(addressId.Value));
      }

      addressModel.OwnerId = ownerId;

      return PartialView("~/Views/Shared/EditorTemplates/Address.cshtml", addressModel);
    }
  }
}
