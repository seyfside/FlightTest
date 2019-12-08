using System;

namespace Flight.DataLayer.Entities
{
    public class Customer:IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public byte Age { get; set; }
    }
}