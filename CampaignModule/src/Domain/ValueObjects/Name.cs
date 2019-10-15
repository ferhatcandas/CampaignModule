using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObjects
{
    public class Name : ValueObjectBase
    {
        public string Value { get; private set; }
        public Name(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name must not be empty");
            }
            else
            {
                Value = name;
            }
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
