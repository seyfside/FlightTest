using System;
using System.Linq.Expressions;
using Flight.DataLayer.Entities;

namespace Flight.DataLayer.Dto
{
    public class CustomerDto
    {
        public string Name { get; set; }    
        public string Email { get; set; }

        public static Expression<Func<Customer,CustomerDto>> Projection
        {
            get
            {
                return x => new CustomerDto
                {
                    Name = x.Name,
                    Email = x.Email
                };
            }
        }
    }
}