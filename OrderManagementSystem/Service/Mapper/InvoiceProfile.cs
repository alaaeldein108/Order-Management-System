using AutoMapper;
using Data.Entities;
using Service.InvoiceServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mapper
{
    public class InvoiceProfile:Profile
    {
        public InvoiceProfile()
        {
            CreateMap<Invoice, InvoiceDto>();
        }
    }
}
