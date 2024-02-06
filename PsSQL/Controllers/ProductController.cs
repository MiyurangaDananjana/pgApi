using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PsSQL.EFCore;
using PsSQL.Models.DTOs;
using PsSQL.Models.Entities;

namespace PsSQL.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ProductController : Controller
    {
        private readonly EfDataContext _DbContext;

        public ProductController(EfDataContext efDataContext)
        {
            this._DbContext = efDataContext;
        }

        [HttpPost("product-save")] // Use an appropriate route for your API
        public IActionResult ProductSave(ProductModel product)
        {
            if(ModelState.IsValid)
            {
                var productData = new Product { 
                    Id = product.Id,
                    name = product.Name,
                    brand = product.Brand,
                    size = product.Size,
                    price = product.Price
                };
                _DbContext.Add(productData);
                _DbContext.SaveChanges();
            }
            return BadRequest("Invalid product data");
        }

        [HttpGet("GetProducts")]
        [Produces("application/xml")]
        public IActionResult GetProducts()
        {
            var products = _DbContext.Products.ToList();

            if (products == null || !products.Any())
            {
                return NotFound("No products found");
            }

            return Ok(products);
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int Id)
        {
            var product = _DbContext.Products.FirstOrDefault(x => x.Id == Id);

            if (product == null)
            {
                return NotFound($"Product with Id {Id} not found");
            }

            return Ok(product);
        }

        [HttpGet("TestProduct")]
        public IActionResult TestProduct()
        {
            return Ok("Hello World");
        }
    }


  
}
