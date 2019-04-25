using System;
using System.Collections.Generic; 
using Entities.Models;
 
namespace Contracts
{
    public interface ITenantRepository : IRepositoryBase<Tenant>
    {
        IEnumerable<Tenant> GetAllTenants(); 
        Tenant GetTenantById(int tenantID);
    }
}