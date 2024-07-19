using AutoMapper;
using Data.Entities;
using Repositories.Interfaces;
using Service.OrderServices.Dtos;
using Service.ProductServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task AddNewProduct(ProductDto input)
        {
            var mappedProduct = mapper.Map<Product>(input);
            await unitOfWork.ProductRepository.AddAsync(mappedProduct);
            await unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await unitOfWork.ProductRepository.GetAllAsync();
            var mappedProducts = mapper.Map<IEnumerable<ProductDto>>(products);
            return mappedProducts;
        }

        public async Task<ProductDto> GetProductByIdAsync(int productId)
        {
            var product = await unitOfWork.ProductRepository.FindAsync(productId);
            var mappedProduct = mapper.Map<ProductDto>(product);
            return mappedProduct;
        }

        public async Task UpdateProductAsync(ProductDto input)
        {
            var mappedProduct = mapper.Map<Product>(input);
            var product= await unitOfWork.ProductRepository.FindAsync(mappedProduct.Id);
            product.Name= mappedProduct.Name;
            product.Price= mappedProduct.Price;
            product.Stock= mappedProduct.Stock;
            unitOfWork.ProductRepository.Update(product);
            await unitOfWork.CompleteAsync();
        }

    }
}
