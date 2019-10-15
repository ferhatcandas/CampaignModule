using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObjects
{
    public class Quantity:ValueObjectBase
    {
        public int Value { get; private set; }
        public Quantity(int quantity)
        {
            Incrase(quantity);
        }
        public void Incrase(int quantity)
        {
            if (quantity < 1)
            {
              throw new ArgumentException("Quantity value should be greater or equal to zero");
            }
            else
            {
                Value += quantity;
            }
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
