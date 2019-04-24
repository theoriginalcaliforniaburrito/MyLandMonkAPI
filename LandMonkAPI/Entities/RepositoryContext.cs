using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            :base(options)
        {
            
        }

        public DbSet<Tenants> Tenants { get; set; }
        public DbSet<Units> Units { get; set; }
        public DbSet<Properties> Properties { get; set; }
    }
}