using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using AutoMapping.App.Core.DTOs;
using AutoMapping.Models;

namespace AutoMapping.App.Core
{
   public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee, ManagerDto>()
                .ForMember(dest=>dest.EmployeeDto, from=>from.MapFrom(x=>
                x.ManagerEmployees))
                .ReverseMap();
            CreateMap<Employee, EmployeePersonalInfoDto>().ReverseMap();
        }
    }
}
