using System;
using Contracts;
using Entities;
using Entities.Extensions;
using Entities.Models;
using System.Linq;
using System.Collections.Generic;

namespace Repository
{
    public class TenantRepository : RepositoryBase<Tenant>, ITenantRepository
    {
        public TenantRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Tenant> GetAllTenants()
        {
            return FindAll()
                .OrderBy(ten => ten.LastName);
        }

        public Tenant GetTenantById(int tenantId)
        {
            return FindByCondition(tenant => tenant.Id.Equals(tenantId))
                .FirstOrDefault();
        }

        public void CreateTenant(Tenant tenant)
        {
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