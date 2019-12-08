using System;

namespace Flight.DataLayer.Entities
{
    public interface IEntity
    { 
        Guid Id { get; set; }
    }
}