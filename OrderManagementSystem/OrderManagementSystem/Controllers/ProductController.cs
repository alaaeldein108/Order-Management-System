using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.CustomerServices.Dtos;
using Service.CustomerServices;
using Service.OrderServices;
using Service.ProductServices;
using Service.ProductServices.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace OrderManagementSystem.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles ="Admin")]
    public class ProductController : BaseController
    {
        private readonly IProductService productService;
        private readonly ILogger<ProductController> logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            this.productService = productService;
            this.logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProduct([FromBody] ProductDto product)
        {
            await productService.AddNewProduct(product);
            return Ok();
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductByIdAsync(int productId)
        {
            var product = await productService.GetProductByIdAsync(productId);
            return Ok(product);
        }
        [HttpGet("products")]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var products = await productService.GetAllProductsAsync();
            return Ok(products);
        }
        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProduct(int productId, [FromBody] ProductDto product)
        {
            if (productId != product.Id)
            {
                return BadRequest("Product ID mismatch");
            }

            var existingProduct = await productService.GetProductByIdAsync(productId);
            if (existingProduct == null)
            {
                return NotFound();
            }

            await productService.UpdateProductAsync(product);
            return Ok();
        }
    }
}
