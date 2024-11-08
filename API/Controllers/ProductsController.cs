using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoeStore.API.Data;
using ShoeStore.API.Models;
using ShoeStore.Shared.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ShoeStoreContext _context;

        public ProductsController(ShoeStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ProductListDto>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            var productListDto = new ProductListDto
            {
                Products = products.Select(p => new ProductDetailDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Currency = p.Currency,
                    ImageUrl = p.ImageUrl,
                    Description = p.Description,
                    CategoryId = p.CategoryId
                }).ToList()
            };
            return Ok(productListDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetailDto>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            var productDetailDto = new ProductDetailDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Currency = product.Currency,
                ImageUrl = product.ImageUrl,
                Description = product.Description,
                CategoryId = product.CategoryId
            };

            return Ok(productDetailDto);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(ProductDetailDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Currency = productDto.Currency,
                ImageUrl = productDto.ImageUrl,
                Description = productDto.Description,
                CategoryId = productDto.CategoryId
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductDetailDto productDto)
        {
            if (id != productDto.Id)
            {
                return BadRequest();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            product.Name = productDto.Name;
            product.Price = productDto.Price;
            product.Currency = productDto.Currency;
            product.ImageUrl = productDto.ImageUrl;
            product.Description = productDto.Description;
            product.CategoryId = productDto.CategoryId;

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}