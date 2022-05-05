using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Common;
using Core.Common.Query;
using Core.Common.Query.Products;
using Core.Common.Results;
using Core.Dto.Category;
using Core.Dto.Product;
using Core.Entities.Products;

namespace Core.Interfaces
{
    public interface IProductService
    {
        Task<PayloadedServiceResult<Product>> AddProductAsync();
        Task<PayloadedServiceResult<PagedResult<IEnumerable<ProductListDto>>>> GetPagedListAsync(ProductsQueryModel query);
        Task<IEnumerable<CategoryListDto>> GetCategoriesAsync();
    }
}