using Contracts;
using Entities;
using Entities.Models;
using Entities.ExtendedModels;
using Entities.Extensions;
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

        public IEnumerable<Property> GetAllProperties()
        {
            return FindAll()
                .OrderBy(o => o.Name);
        }

        public Property GetPropertyById(Guid propertyId)
        {
            return FindByCondition(property => property.Id.Equals(propertyId))
                .DefaultIfEmpty(new Property())
                .FirstOrDefault();
        }

        public PropertyExtended GetOwnerWithDetails(Guid propertyId)
        {
            return new PropertyExtended(GetPropertyById(propertyId))
            {
                Units = RepositoryContext.Units
                    .Where(a => a.PropertyId == propertyId)
            };
        }     

        public void CreateProperty(Property property)
        {
            property.Id = Guid.NewGuid();
            Create(property);
            Save();
        }

        public void UpdateProperty(Property dbProperty, Property property)
        {
            dbProperty.Map(property);
            Update(dbProperty);
            Save();
        }

        public void DeleteProperty(Property property)
        {
            Delete(property);
            Save();
        }


    }
}