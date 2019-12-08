using System;
using System.Linq.Expressions;
using Flight.DataLayer.Entities;

namespace Flight.DataLayer.Dto
{
    public class ProductDto
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public static Expression<Func<Product,ProductDto>> Projection { get; set; }
    }
}