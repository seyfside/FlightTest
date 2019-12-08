using System;
using System.Linq;
using Flight.DataLayer.Dto;
using Flight.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flight.DataLayer.Repositories
{
    public class ProductRepository :GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(IUnitOfWork<DbContext> unitOfWork) : base(unitOfWork) { }

        public PagedResult<ProductDto> Search(SearchModel<Product> searchModel)
        {
            var query = searchModel.Where != null ? Table.Where(searchModel.Where) : Table;
            
            if(searchModel.OrderBy!=null)
                query = searchModel.IsDescending 
                    ? query.OrderByDescending(searchModel.OrderBy) 
                    : query.OrderBy(searchModel.OrderBy);

            var pagedResult = new PagedResult<ProductDto>
            {
                CurrentPage = searchModel.CurrentPage, PageSize = searchModel.PageSize, RowCount = query.Count()
            };

            var pageCount = (double)pagedResult.RowCount / searchModel.PageSize;
            pagedResult.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (searchModel.CurrentPage - 1) * searchModel.PageSize;
            pagedResult.Result = query.Skip(skip).Take(searchModel.PageSize).Select(ProductDto.Projection).ToList();

            return pagedResult;
        
        }

        public PagedResult<ProductDetailDto> SearchCategoryIncluded(SearchModel<Product> searchModel)
        {
            var query = searchModel.Where != null ? Table.Where(searchModel.Where) : Table;
            query.Include(x => x.Category);
            
            if(searchModel.OrderBy!=null)
                query = searchModel.IsDescending 
                    ? query.OrderByDescending(searchModel.OrderBy) 
                    : query.OrderBy(searchModel.OrderBy);

            var pagedResult = new PagedResult<ProductDetailDto>
            {
                CurrentPage = searchModel.CurrentPage, PageSize = searchModel.PageSize, RowCount = query.Count()
            };

            var pageCount = (double)pagedResult.RowCount / searchModel.PageSize;
            pagedResult.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (searchModel.CurrentPage - 1) * searchModel.PageSize;
            
            pagedResult.Result = query.Skip(skip).Take(searchModel.PageSize).Select(ProductDetailDto.Projection).ToList();

            return pagedResult;
        }
    }
}