using System;
using Contracts;
using Entities;
using Entities.Extensions;
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

        public IEnumerable<Unit> GetAllUnits()
        {
            return FindAll()
                .OrderBy(unit => unit.UnitName);
        }
        public Unit GetUnitById(int UnitId)
        {
            return FindByCondition(account => account.Id.Equals(UnitId))
            .DefaultIfEmpty(new Unit())
            .FirstOrDefault();
        }

        public void CreateUnit(Unit unit)
        {
            Create(unit);
            Save();
        }

        public IEnumerable<Unit> UnitsByProperty(int propertyId) {
            var units = FindByCondition(u => u.PropertyId.Equals(propertyId));

            return units;
        }

        public void UpdateUnit(Unit dbUnit, Unit unit)
        {
            dbUnit.Map(unit);
            Update(dbUnit);
            Save();
        }

    }
}