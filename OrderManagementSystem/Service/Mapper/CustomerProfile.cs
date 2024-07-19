using AutoMapper;
using Data.Entities;
using Service.CustomerServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mapper
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer,CustomerDto>().ReverseMap();
        }
    }
}
