using Flight.DataLayer.Dto;
using Flight.DataLayer.Entities;

namespace Flight.DataLayer.Repositories
{
    public interface ICustomerRepository:IGenericRepository<Customer>
    {
        PagedResult<CustomerDto> Search(SearchModel<Customer> searchModel);
    }
}