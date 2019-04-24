using System;
using Contracts;
using Entities;
using Entities.Extensions;
using Entities.ExtendedModels;
using Entities.Models;
using System.Linq;
using System.Collections.Generic;

namespace Repository
{
    class UnitRepository : RepositoryBase<Unit>, IUnitRepository
    {
        public UnitRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {
            
        }

        public IEnumerable<Unit> UnitsByOwner(Guid PropertyId)
        {
            return FindByCondition(a => a.PropertyId.Equals(propertyId));
        }

        public IEnumerable<Property> GetAllUnits()
        {
            return FindAll()
                .OrderBy(o => o.DateCreated);
        }
        public Unit GetUnitById(Guid unitId)
        {
            return FindByCondition(unit => unit.Id.Equals(unitId))
            .DefaultIfEmpty(new Unit())
            .FirstOrDefault();
        }
        public void CreateUnit(Unit unit)
        {
            unit.Id = Guid.NewGuid();
            Create(unit);
            Save();
        }
        public void UpdateUnit(Unit dbUnit, Unit unit)
        {
            dbUnit.Map(unit);
            Update(dbUnit);
            Save();
        }

        public void DeleteUnit(Unit unit)
        {
            Delete(unit);
            Save();
        }
    }
}