using System;

namespace Flight.DataLayer.Entities
{
    public class Product:IEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
    }
}