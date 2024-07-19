using AutoMapper;
using Data.Entities;
using Service.OrderServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mapper
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<Order,OrderDto>()
                .ForMember(dest=>dest.CustomerId,options=>options.MapFrom(src=>src.Customer.Id))
                .ReverseMap();

            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.CustomerId, options => options.MapFrom(src => src.Customer.Id))
                .ReverseMap();


        }
    }
}
