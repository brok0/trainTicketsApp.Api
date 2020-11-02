using System;
using System.Collections.Generic;
using System.Text;

namespace SplitMoney.Domain.Abstraction
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
