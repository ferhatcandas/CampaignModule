using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
    }
}
