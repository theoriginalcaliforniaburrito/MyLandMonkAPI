using Entities;
using Contracts;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IPropertyRepository _property;
        private IUnitRepository _unit;
        private ITenantRepository _tenant;
        private IUserRepository _user;


        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public IPropertyRepository Property {
            get {
                if (_property == null)
                {
                    _property = new PropertyRepository(_repoContext);
                }
                return _property;
            }
        }

        public IUnitRepository Unit {
            get {
                if (_unit == null)
                {
                    _unit = new UnitRepository(_repoContext);
                }
                return _unit;
            }
        }

        public ITenantRepository Tenant {
            get {
                if (_tenant == null)
                {
                    _tenant = new TenantRepository(_repoContext);
                }
                return _tenant;
            }
        }

        public IUserRepository User {
            get {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }
    }
}