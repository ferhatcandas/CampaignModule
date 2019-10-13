using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObjects
{
    public class Duration : ValueObjectBase
    {
        public DateTime Value { get; private set; }
        public Duration(int hour)
        {
            if (hour < 0)
            {
                throw new LogicException("Duration value is greather than zero");
            }
            Value = DateTime.Now.AddHours(hour);
        }
        public void Incrase(int hour)
        {
            //TODO
            if (hour < 0)
            {
                throw new LogicException("Duration value is greather than zero");
            }
            Value = Value.AddHours(hour);
        }
    }
}
