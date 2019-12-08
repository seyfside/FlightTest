using System;
using System.Linq.Expressions;
using Flight.DataLayer.Entities;

namespace Flight.DataLayer.Dto
{
    public class CategoryDto
    {
        public string Name { get; set; }

        public static Expression<Func<Category, CategoryDto>> Projection
        {
            get
            {
                return x=>new CategoryDto
                {
                    Name = x.Name
                };
            }
        }

        public static CategoryDto FromEntity(Category entity)
        {
            return Projection.Compile().Invoke(entity);
        }
    }
}