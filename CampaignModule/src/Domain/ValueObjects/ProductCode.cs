using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObjects
{
    public class ProductCode : ValueObjectBase
    {
        public string Value { get; private set; }

        public ProductCode(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
              throw new ArgumentException("Product code must not be empty.");
            }
            else
            {
                Value = code;
            }
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
