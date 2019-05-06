using Entities.Models;
using System;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IPropertyRepository Property { get; }
        IUnitRepository Unit { get; }
        ITenantRepository Tenant { get; }
        IUserRepository User { get; }
    }
}