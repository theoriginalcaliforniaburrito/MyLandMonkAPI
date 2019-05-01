using System;
using System.Collections.Generic;
using Entities.Models;
using Entities.ExtendedModels;
 
namespace Contracts
{
    public interface IPropertyRepository : IRepositoryBase<Property>
    {
        IEnumerable<Property> GetAllProperty();
        Property GetPropertyById(int propertyId); // use int not GUID
        PropertyExtended GetPropertyWithDetails(int propertyId); // use int not GUID
        void CreateProperty(Property prop);
        void UpdateProperty(Property dbProperty, Property prop);
        void DeleteProperty(Property prop);
        
    }
}
