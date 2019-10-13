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
                throw new LogicException("Product code must not be empty.");
            }
            Value = code;
        }
    }
}
