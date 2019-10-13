using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObjects
{
    public class Stock : ValueObjectBase
    {
        public int Value { get; private set; }
        public Stock(int stock)
        {
            if (stock < 0)
            {
                throw new LogicException("Stock value should be greater or equal to zero");
            }
        }
        public void DecraseStock(int value)
        {
            CheckStockExist(value);
            Value = Value - value;
        }
        public void CheckStockExist(int value)
        {
            if (Value < value)
            {
                throw new LogicException("There is no enough stock");
            }
        }
    }
}
