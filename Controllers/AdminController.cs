using eBookShop.Model;
using eBookShop.Repositories.BALRepository;
using eBookShop.Services.BALServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBookShop.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IProductBal _ProductBal;
        public AdminController(IProductBal productBal)
        {
            _ProductBal = productBal;
        }
        [HttpPost("addproduct")]
        public async Task<IActionResult> AddProduct(ProductModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(data);
            }
            await _ProductBal.AddProductAsync(data);
            return Ok();
        }
        [HttpGet("productList")]
        public async Task<IActionResult> GetProduct()
        {
            var data = await _ProductBal.GetProductAsync();
            return Ok(data);
        }
    }
}
