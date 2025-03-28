using eBookShop.DTOs;
using eBookShop.Model;
using eBookShop.Repositories.BALRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBookShop.Controllers
{
    [Route("api/products")] 
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductBal _productBal;
        public ProductController(IProductBal productBal)
        {
            _productBal = productBal;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm] ProductDto data)
        {
            if (data.ProductImage == null || data.ProductPdf == null)
            {
                return BadRequest(new { message = "Product Image and Product PDF cannot be null" });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _productBal.AddProductAsync(data);
            return Ok(new { message = "Product added successfully" });
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productBal.GetProductById(id);
            if (product == null)
            {
                return NotFound(new { message = "Product not found" });
            }
            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productBal.GetProductAsync();
            return Ok(products);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productBal.DeleteProduct(id);
            return Ok(new { message = "Product deleted successfully" });
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDto data)
        {
            await _productBal.UpdateProductAsync(data);
            return Ok(new { message = "Product updated successfully" });
        }
        [Authorize]
        [HttpPost("orderProduct")]
        public async Task<IActionResult> OrderProduct()
        {
            return Ok();
        }
    }
}
