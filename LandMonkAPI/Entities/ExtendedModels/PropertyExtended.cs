using System;
using System.Collections.Generic;
using Entities.Models;

namespace Entities.ExtendedModels
{
    public class PropertyExtended : IEntity
    {
        public int Id { get; set; }
        public string PropertyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public IEnumerable<Unit> Units { get; set; }

        public PropertyExtended()
        {
        }

        public PropertyExtended(Property property)
        {
            Id = property.Id;
            PropertyName = property.PropertyName;
            Address = property.Address;
            City = property.City;
            State = property.State;
            ZipCode = property.ZipCode;
        }
    }
}