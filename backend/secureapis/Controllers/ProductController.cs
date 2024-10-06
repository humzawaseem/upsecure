using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using secureapis.Controllers;
using secureapis.Models;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductRepository _repository;
        public ProductController(ILogger<ProductController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _repository = productRepository;

        }

        [HttpPost("CreateAsync")]
        public async Task<IActionResult> CreateAsync(Product product)
        {
            try
            {
                await _repository.CreateAsync(product);
                return Ok(product);
            }
            catch (Exception e)
            {

                throw;
            }
          
        }


        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("GetByIdAsync/{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var product = await _repository.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync(string id, Product product)
        {
            await _repository.UpdateAsync(id, product);
            return Ok();
        }

        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            await _repository.DeleteAsync(id);
            return Ok();
        }





    }
}
