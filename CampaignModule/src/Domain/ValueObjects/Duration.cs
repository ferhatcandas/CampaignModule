using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObjects
{
    public class Duration : ValueObjectBase
    {
        public int Value { get; private set; }
        public Duration(int hour)
        {
            if (hour < 0)
            {
               Logger.Log("Duration value is greather than zero");
            }
            else
            {
                Value = hour;
            }
        }
        public void Incrase(int hour)
        {
            if (hour < 0)
            {
               Logger.Log("Duration value is greather than zero");
            }
            else
            {
                Value += hour;
            }
        }
    }
}
