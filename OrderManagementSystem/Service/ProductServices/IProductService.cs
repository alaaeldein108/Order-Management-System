using Service.OrderServices.Dtos;
using Service.ProductServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ProductServices
{
    public interface IProductService
    {
        Task AddNewProduct(ProductDto input);
        Task UpdateProductAsync(ProductDto input);
        Task<ProductDto> GetProductByIdAsync(int productId);
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
    }
}
