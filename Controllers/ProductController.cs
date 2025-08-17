using ApiProducts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
namespace ApiProducts.Controllers
{
    [ApiController]
    [Route("api/products")]

    public class ProductController : ControllerBase
    {
        private readonly ProductContext _context;
        private readonly ProductService _productService;

        public ProductController(ProductContext context, ProductService productService)
        {
            _context = context;
            _productService = productService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();

            if (products == null || products.Count == 0)
                return NotFound("No hay productos en la base de datos.");

            return Ok(products);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Products>> GetProductById(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return NotFound($"No se encontró un producto con Id {id}.");

            return Ok(product);
        }


        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Products>> CreateProduct([FromBody] Products product)
        {
            if (product == null)
                return BadRequest("El producto no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(product.Name) || product.Price <= 0)
                return BadRequest("El nombre y el precio son obligatorios.");

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProducts), new { id = product.Id }, product);
        }


        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Products updatedProduct)
        {
            if (id != updatedProduct.Id)
                return BadRequest("El Id del producto no coincide con el parámetro de la URL.");

            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct == null)
                return NotFound($"No se encontró un producto con Id {id}.");

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Description = updatedProduct.Description;
            existingProduct.Price = updatedProduct.Price;
            existingProduct.Stock = updatedProduct.Stock;
            existingProduct.Status = updatedProduct.Status;

            await _context.SaveChangesAsync();

            return NoContent(); // 204 - Éxito sin contenido
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound($"No se encontró un producto con Id {id}.");

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }

}