using Contracts;
using Entities;
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
        
        public IEnumerable<Property> GetAllProperty()
        {
            return FindAll()
                .OrderBy(o => o.PropertyName);
        }

        public Property GetPropertyById(int propertyId)
        {
            return FindByCondition(property => property.Id.Equals(propertyId))

            .DefaultIfEmpty(new Property())
            .FirstOrDefault();
        }

    }
}