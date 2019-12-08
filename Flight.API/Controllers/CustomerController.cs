using System.Collections.Generic;
using Flight.DataLayer;
using Flight.DataLayer.Dto;
using Flight.DataLayer.Entities;
using Flight.DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Flight.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController( IUnitOfWork<EfDbContext> unitOfWork)
        {
            _customerRepository=new CustomerRepository(unitOfWork);
        }
        [HttpGet]
        public IEnumerable<CustomerDto> GetCustomers()
        {
            var searchModel=new SearchModel<Customer>
            {
                CurrentPage = 1,
                PageSize = 1,
                IsDescending = true,
                OrderBy = x=>x.Id,
                Where = x=>x.Age>0
            };
            return _customerRepository.Search(searchModel).Result;
        }
        
    }
}