using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Extensions
{
    public static class PropertyExtensions
    {
        public static void Map(this Property dbProperty, Property property)
        {
            dbProperty.PropertyName = property.PropertyName;
            dbProperty.Address = property.Address;
            dbProperty.City = property.City;
            dbProperty.State = property.State;
            dbProperty.ZipCode = property.ZipCode;
        }
    }
}

