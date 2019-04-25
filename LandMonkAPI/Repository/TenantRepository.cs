using System;
using Contracts;
using Entities;
using Entities.Models;
using System.Linq;
using System.Collections.Generic;

namespace Repository
{
    public class TenantRepository : RepositoryBase<Tenant>, ITenantRepository
    {
        public TenantRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {
        }

        public IEnumerable<Tenant> GetAllTenants()
        {
            return FindAll()
                .OrderBy(ten => ten.LastName);
        }

        public Tenant GetTenantById(Guid tenantId)
        {
            return FindByCondition(tenantId => tenantId.Id.Equals(tenantId))
                .FirstOrDefault();
        }
    }
}