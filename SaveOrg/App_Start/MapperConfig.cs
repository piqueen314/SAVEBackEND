using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dataModels = SaveOrg.Models;
using viewModels = SaveOrg.ViewModels;

namespace SaveOrg.App_Start
{
  public static class MapperConfig
  {
    public static void RegisterMaps()
    {
      Mapper.CreateMap<dataModels.Student, viewModels.Student>();
      Mapper.CreateMap<viewModels.Student, dataModels.Student>();
      
      Mapper.CreateMap<dataModels.Student, dataModels.StudentHistory>();

      Mapper.CreateMap<dataModels.Address, viewModels.Address>();
      Mapper.CreateMap<viewModels.Address, dataModels.Address>();

      Mapper.CreateMap<dataModels.StudentAddress, viewModels.StudentAddress>();
      Mapper.CreateMap<viewModels.StudentAddress, dataModels.StudentAddress>();

    }
  }
}
