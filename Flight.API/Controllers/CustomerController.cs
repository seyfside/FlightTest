using System.Collections.Generic;
using Flight.DataLayer;
using Flight.DataLayer.Dto;
using Flight.DataLayer.Entities;
using Flight.DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flight.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork<EfDbContext> _unitOfWork;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;

        public CustomerController( IUnitOfWork<EfDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _customerRepository=new CustomerRepository(_unitOfWork);
            _productRepository=new ProductRepository(_unitOfWork);
        }
        
        [HttpGet]
        [Route("customers")]
        public IEnumerable<CustomerDto> GetCustomers()
        {
            var customer=new Customer
            {
                Age = 10,
                Email = "email",
                Name = "name"
            };
            
            _customerRepository.Insert(customer);
            _unitOfWork.Save();
            
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

        [HttpGet]
        [Route("products")]
        public IEnumerable<ProductDetailDto> GetProducts()
        {
            var category=new Category
            {
                Name = "Category 1 name"
            };
            
            var product=new Product
            {
                Category = category,
                ImageUrl = "image:Url",
                Price = 10d,
                Title = "product Title"
            };
            
            _productRepository.Insert(product);
            _unitOfWork.Save();
            
            var searchModel=new SearchModel<Product>
            {
                CurrentPage = 1,
                PageSize = 1,
                IsDescending = true,
                OrderBy = x=>x.Id
            };

            return _productRepository.SearchCategoryIncluded(searchModel).Result;
        }
        
    }
}