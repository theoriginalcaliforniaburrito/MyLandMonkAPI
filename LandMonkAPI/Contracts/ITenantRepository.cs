using System;
using System.Collections.Generic; 
using Entities.Models;
 
namespace Contracts
{
    public interface ITenantRepository : IRepositoryBase<Tenant>
    {
        IEnumerable<Tenant> GetAllTenants(); 
        Tenant GetTenantById(int tenantID);
        void CreateTenant(Tenant tenant);
        void UpdateTenant(Tenant dbTenant, Tenant tenant);
        void DeleteTenant(Tenant tenant);
    }
}