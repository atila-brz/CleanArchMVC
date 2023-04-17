using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchMVC.Aplication.DTOs;
using CleanArchMVC.Domain.Entities;

namespace CleanArchMVC.Aplication.Mapper
{
    public class DomainToDTOMappingProfile: Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
