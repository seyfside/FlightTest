using System;
using System.Linq;
using Flight.DataLayer.Dto;
using Flight.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flight.DataLayer.Repositories
{
    public class CustomerRepository :GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IUnitOfWork<DbContext> unitOfWork) : base(unitOfWork) { }

        public PagedResult<CustomerDto> Search(SearchModel<Customer> searchModel)
        {
            var query = searchModel.Where != null ? Table.Where(searchModel.Where) : Table;
            
            if(searchModel.OrderBy!=null)
                query = searchModel.IsDescending 
                    ? query.OrderByDescending(searchModel.OrderBy) 
                    : query.OrderBy(searchModel.OrderBy);

            var pagedResult = new PagedResult<CustomerDto>
            {
                CurrentPage = searchModel.CurrentPage, PageSize = searchModel.PageSize, RowCount = query.Count()
            };

            var pageCount = (double)pagedResult.RowCount / searchModel.PageSize;
            pagedResult.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (searchModel.CurrentPage - 1) * searchModel.PageSize;
            pagedResult.Result = query.Skip(skip).Take(searchModel.PageSize).Select(CustomerDto.Projection).ToList();

            return pagedResult;
        }
    }
}