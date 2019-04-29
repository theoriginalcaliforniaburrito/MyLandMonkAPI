using System;
using Entities.Models;
using System.Collections.Generic;
 
namespace Contracts
{
    public interface IUnitRepository
    {
        IEnumerable<Unit> UnitsByProperty(int propertyId);
        IEnumerable<Unit> GetAllUnits();
        Unit GetUnitById(int UnitId);
        void CreateUnit( Unit unit);
    }
}