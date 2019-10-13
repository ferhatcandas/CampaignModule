using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObjects
{
    public class TargetSalesCount : ValueObjectBase
    {
        public int Value { get; private set; }
        public TargetSalesCount(int count)
        {
            if (count < 0)
            {
                throw new LogicException("Target sales count value must be greather than zero");
            }
            Value = count;
        }
    }
}
