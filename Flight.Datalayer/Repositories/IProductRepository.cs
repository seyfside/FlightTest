using Flight.DataLayer.Dto;
using Flight.DataLayer.Entities;

namespace Flight.DataLayer.Repositories
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        PagedResult<ProductDto> Search(SearchModel<Product> searchModel);
        PagedResult<ProductDetailDto> SearchCategoryIncluded(SearchModel<Product> searchModel);
    }
}