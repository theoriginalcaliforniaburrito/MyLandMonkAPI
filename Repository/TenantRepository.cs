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

        public IEnumerable<Tenant> GetAllTenants()
        {
            return FindAll()
                .OrderBy(o => o.Name);
        }

        public Tenant GetTenantById(Guid tenantId)
        {
            return FindByCondition(tenant => tenant.Id.Equals(tenantId))
            .DefaultIfEmpty(new Tenant())
            .FirstOrDefault();
        }

        public TenantExtended GetTenantWithDetails(Guid tenantId)
        {
            return new TenantExtended(GetTenantById(tenantId))
            {
                    a => a.TenantId == tenantId
            };
        }

        public void CreateTenant(Tenant tenant)
        {
            tenant.Id = Guid.NewGuid();
            Create(tenant);
            Save();
        }

        public void UpdateTenant(Tenant dbTenant, Tenant tenant)
        {
            dbTenant.Map(tenant);
            Update(dbTenant);
            Save();
        }

        public void DeleteTenant(Tenant tenant)
        {
            Delete(tenant);
            Save();
        }

    }
}