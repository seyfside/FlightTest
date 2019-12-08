using System;
using System.Collections.Generic;

namespace Flight.DataLayer.Entities
{
    public class Category:IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}