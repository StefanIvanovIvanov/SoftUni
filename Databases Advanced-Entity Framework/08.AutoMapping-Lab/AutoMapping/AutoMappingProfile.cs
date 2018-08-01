using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace AutoMapping
{
    public class AutoMappingProfile : Profile
    {//We can extract our configuration to a class (Profile)
        public AutoMappingProfile()
        {
            CreateMap<Product, ProductDTO>();
            // CreateMap<Category, CategoryDto>();
        }

    }
}
