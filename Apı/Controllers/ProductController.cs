using Core.DbModels;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apı.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private IGenericRepository<Product> _productRepository;
        private IGenericRepository<ProductBrand> _productBrandRepository;
        private IGenericRepository<ProductType> _productTypeRepository;
        public ProductController(IGenericRepository<Product> productRepository, IGenericRepository<ProductType> productTypeRepository, IGenericRepository<ProductBrand> productBrandRepository)
        {
            _productRepository = productRepository;
            _productTypeRepository = productTypeRepository;
            _productBrandRepository = productBrandRepository;
        }
       
        [HttpGet("getall")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var data = await  _productRepository.ListAllAsync();
            return Ok(data);
        }
        [HttpGet("get/{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var data = await _productRepository.GetIdByAsync(id);
            return Ok(data);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            var data = await _productBrandRepository.ListAllAsync();
            return Ok(data);
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            var data = await _productTypeRepository.ListAllAsync();
            return Ok(data);
        }
    }


}
