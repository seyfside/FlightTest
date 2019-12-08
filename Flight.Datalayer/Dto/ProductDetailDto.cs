using System;
using System.Linq.Expressions;
using Flight.DataLayer.Entities;

namespace Flight.DataLayer.Dto
{
    public class ProductDetailDto
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        
        public CategoryDto Category { get; set; }

        public static Expression<Func<Product, ProductDetailDto>> Projection
        {
            get
            {
                return x=> new ProductDetailDto
                {
                    Title = x.Title,
                    ImageUrl = x.ImageUrl,
                    Category = CategoryDto.FromEntity(x.Category)
                };
            }
        }
    }
}