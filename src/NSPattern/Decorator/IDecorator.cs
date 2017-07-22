using System;
using System.Collections.Generic;
using System.Text;

namespace NSPattern.Decorator
{
    public interface IDecorator<I> : IDecorateable
        where I : IDecorateable
    {
        I Component { get; set; }
    }
}
