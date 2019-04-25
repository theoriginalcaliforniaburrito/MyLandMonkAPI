using System;
using System.Collections.Generic;
using Entities.Models;
using Entities.ExtendedModels;
 
namespace Contracts
{
    public interface IPropertyRepository : IRepositoryBase<Property>
    {
        IEnumerable<Property> GetAllProperties();
        Property GetPropertyById(int propertyId); // use int not GUID
        PropertyExtended GetPropertyWithDetails(int propertyId); // use int not GUID
    }
}