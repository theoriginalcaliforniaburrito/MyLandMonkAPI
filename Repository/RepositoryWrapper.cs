using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IPropertyRepository _property;
        private IUnitRepository _unit;



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
    }
}