using AutoMapper;
using Business.Interfaces;
using Entity.DTOs;
using Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, IMapper mapper, ILogger<ProductController> logger)
        {
            _productService = productService;
            _mapper = mapper;
            _logger = logger;
        }
        /// <summary>
        ///  All Products api/Product/GetAllProducts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            //log
            _logger.LogInformation("Products listed");


           var products=await _productService.GetAllAsync();
            var productsDtos=_mapper.Map<List<ProductDto>>(products);
            return Ok(productsDtos);
        }
        /// <summary>
        /// GetByIdProduct api/Product/GetByIdProduct/1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProduct(int id)
        {
            //log
            _logger.LogInformation("Product information");

            var product = await _productService.GetByIdAsync(id);
            var productDtos = _mapper.Map<ProductDto>(product);
            return Ok(productDtos);
        }
        /// <summary>
        /// Added api/Product/AddProduct
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDto dto)
        {
            //log
            _logger.LogInformation("Add Product");

            var addProduct = await _productService.AddAsync(_mapper.Map<Product>(dto));
            var productDto= _mapper.Map<ProductDto>(addProduct);
            return Created("", new ProductDto { Name=dto.Name,Price=dto.Price,CreatedDate=dto.CreatedDate,CategoryId=dto.CategoryId});

        }

        /// <summary>
        /// Updated api/Product/UpdateProduct
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductDto dto)
        {
            //log
            _logger.LogInformation("Update product"); 

            _productService.Update(_mapper.Map<Product>(dto));
            return Ok();

        }
        /// <summary>
        /// Delete api/DeleteProduct/3
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            //log
            _logger.LogInformation("Delete Product"); 

            var product = await _productService.GetByIdAsync(id);
            if (product==null)
            {
                return BadRequest();
            }
            _productService.Remove(product);
            return NoContent();
        }
    }
}
