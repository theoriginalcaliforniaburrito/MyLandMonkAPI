using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Extensions
{
    public static class UnitExtensions
    {
        public static void Map(this Unit dbUnit, Unit unit)
        {
            dbUnit.UnitName = unit.UnitName;
            dbUnit.BedroomCount = unit.BedroomCount;
            dbUnit.BathroomCount = unit.BathroomCount;
            dbUnit.SquareFootage = unit.SquareFootage;
        }
    }
}

