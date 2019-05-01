using System.Data.Common;
using Contracts;
using Entities;
using Entities.ExtendedModels;
using Entities.Extensions;
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

        public PropertyExtended GetPropertyWithDetails(int propertyId) // use int not GUID
        {
            return new PropertyExtended(GetPropertyById(propertyId))
            {
                Units = RepositoryContext.Units
                    .Where(a => a.PropertyId == propertyId)
            };
        }     
        public Property GetPropertyById(int propertyId)
        {
            return FindByCondition(property => property.Id.Equals(propertyId))

            .DefaultIfEmpty(new Property())
            .FirstOrDefault();
        }

        public void CreateProperty(Property prop)
        {
            Create(prop);
            Save();
        }
        public void UpdateProperty(Property dbProperty, Property prop)
        {
            dbProperty.Map(prop);
            Update(dbProperty);
            Save();
        }
        public void DeleteProperty(Property prop)
        {
            Delete(prop);
            Save();
        }
    }
}