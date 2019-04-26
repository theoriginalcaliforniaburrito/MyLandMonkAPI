using Contracts;
using Entities;
using Entities.ExtendedModels;
using Entities.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Repository
{
    public class PropertyRepository : RepositoryBase<Property>, IPropertyRepository
    {
        public PropertyRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {
            
        }

        public PropertyExtended GetPropertyWithDetails(int propertyId) // use int not GUID
        {
            return new PropertyExtended(GetPropertyById(propertyId))
            {
                Units = RepositoryContext.Units
                    .Where(a => a.PropertyId == propertyId)
            };
        }     
    }
}