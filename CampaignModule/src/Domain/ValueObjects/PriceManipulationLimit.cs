using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObjects
{
    public class PriceManipulationLimit : ValueObjectBase
    {
        public int Value { get; private set; }
        public PriceManipulationLimit(int limit)
        {
            if (limit < 0)
            {
                throw new LogicException("Price manipulation limit must be greather than zero");
            }
            Value = limit;
        }
    }
}
