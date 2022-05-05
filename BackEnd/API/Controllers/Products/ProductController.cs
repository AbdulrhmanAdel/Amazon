using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Attributes;
using api.Attributes.Authorization;
using api.Controllers;
using Core.Common.Query.Products;
using Core.Dto.Category;
using core.Dto.Product;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Controllers.Products
{
    [Authorize]
    public class ProductController : BaseV1ApiController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        [HttpGet("GetPagedList")]
        public async Task<IActionResult> GetProductsAsync([FromQuery] ProductsQueryModel query)
        {
            var result = await _productService.GetPagedListAsync(query);

            if (result.Success)
            {
                return PagedResult(result.Payload.Data, result.Payload.TotalCount);
            }

            return InvalidRequest();
        }


        [AllowAdminsOnly]
        [UploadFiles("products")]
        [HttpPost("Post")]
        public async Task<IActionResult> AddProductAsync([FromForm] AddProductDto productDto)
        {
            return Ok(HttpContext);
        }


        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            return ListResult(await _productService.GetCategoriesAsync());
        }

        
    }
}