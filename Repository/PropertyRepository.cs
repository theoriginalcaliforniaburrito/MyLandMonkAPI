// using Contracts;
using Entities;
using Entities.Models;
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



    }
}