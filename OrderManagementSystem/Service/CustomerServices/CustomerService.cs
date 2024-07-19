using AutoMapper;
using Data.Entities;
using Repositories.Interfaces;
using Service.CustomerServices.Dtos;
using Service.OrderServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CustomerServices
{
    public class CustomerService:ICustomerService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CustomerService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task AddCustomerAsync(CustomerDto customerDto)
        {
            var customer = mapper.Map<Customer>(customerDto);
            await unitOfWork.CustomerRepository.AddAsync(customer);
            await unitOfWork.CompleteAsync();
        }
        public async Task<IEnumerable<Order>> GetAllOrders(int customerId)
        {
            var orders= await unitOfWork.CustomerRepository.GetOrdersAsync(customerId);
            var mappedOrders=mapper.Map<IEnumerable<OrderWithTotalAmountDto>>(orders);
            return orders;
        }

        public async Task<IEnumerable<CustomerDto>> GetCustomers()
        {
            var customers = await unitOfWork.CustomerRepository.GetAllCustomers();
            var mappedCustomers = mapper.Map<IEnumerable<CustomerDto>>(customers);
            return mappedCustomers;
        }
    }
}
