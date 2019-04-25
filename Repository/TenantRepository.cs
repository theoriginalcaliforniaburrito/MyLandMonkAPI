using System;
using Contracts;
using Entities;
using Entities.Extensions;
using Entities.Models;
using System.Linq;
using System.Collections.Generic;
using Entities.ExtendedModels;

namespace Repository
{
    public class TenantRepository : RepositoryBase<Tenant>, ITenantRepository
    {
        public TenantRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {
            
        }


    }
}