using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObjects
{
    public class Price : ValueObjectBase
    {
        public double Value { get; private set; }

        public Price(double price)
        {
            if (price < 0)
            {
                throw new LogicException("Price value should be greater or equal to zero");
            }
            Value = price;
        }
    }
}
