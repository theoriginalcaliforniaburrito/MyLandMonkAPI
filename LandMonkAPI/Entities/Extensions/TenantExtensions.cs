using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Extensions
{
    public static class TenantExtensions
    {
        public static void Map(this Tenant dbTenant, Tenant tenant)
        {
            dbTenant.FirstName = tenant.FirstName;
            dbTenant.LastName = tenant.LastName;
            dbTenant.Email = tenant.Email;
            dbTenant.CellPhone = tenant.CellPhone;
        }
    }
}

