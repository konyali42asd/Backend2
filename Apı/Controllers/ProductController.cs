using Apı.Dtos;
using AutoMapper;
using Core.DbModels;
using Core.Interface;
using Core.Spacitifition;
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
        private IMapper _mapper;
        public ProductController(IGenericRepository<Product> productRepository,
            IGenericRepository<ProductType> productTypeRepository,
            IGenericRepository<ProductBrand> productBrandRepository,
            IMapper mapper
            )
        {
            _productRepository = productRepository;
            _productTypeRepository = productTypeRepository;
            _productBrandRepository = productBrandRepository;
            _mapper = mapper;
        }
       
        [HttpGet("getall")]
        public async Task<ActionResult<List<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductSpesification();
            var data = await  _productRepository.ListAsync(spec);
            //return data.Select(pro => new ProductToReturnDto
            //{
            //    Id = pro.Id,
            //    Name = pro.Name,
            //    Description = pro.Description,
            //    ImgUrl = pro.ImgUrl,
            //    Price = pro.Price,
            //    ProductBrand = pro.ProductBrand != null ? pro.ProductBrand.Name : string.Empty,
            //    ProductType = pro.ProductType != null ? pro.ProductType.Name : string.Empty,
            //}).ToList();
            return Ok(_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDto>>(data));
        }
        [HttpGet("get/{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductSpesification(id);
            var data = await _productRepository.GetEntityWithSpec(spec);
            //return new ProductToReturnDto
            //{
            //    Id = data.Id,
            //    Name = data.Name,
            //    Description = data.Description,
            //    ImgUrl = data.ImgUrl,
            //    Price = data.Price,
            //    ProductBrand = data.ProductBrand != null ? data.ProductBrand.Name : string.Empty,
            //    ProductType = data.ProductType != null ? data.ProductType.Name : string.Empty,
            //};
            return _mapper.Map<Product, ProductToReturnDto>(data);  
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
