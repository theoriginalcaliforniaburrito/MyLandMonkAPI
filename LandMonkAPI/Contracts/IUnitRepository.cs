using Entities.Models;
using System.Collections.Generic;
 
namespace Contracts
{
    public interface IUnitRepository
    {
        IEnumerable<Unit> GetAllUnits();
    }
}