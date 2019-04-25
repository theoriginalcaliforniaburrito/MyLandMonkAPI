using Entities.Models;
using System.Collections.Generic;
using System;
 
namespace Contracts
{
    public interface IPropertyRepository : IRepositoryBase<Property>
    {
        IEnumerable<Property> GetAllProperty();

        Property GetPropertyById(int propertyId);

    }
}