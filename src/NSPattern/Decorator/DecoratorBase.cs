using System;
using System.Collections.Generic;
using System.Text;

namespace NSPattern.Decorator
{
    public abstract class DecoratorBase<I> : IDecorator<I>
            where I : IDecorateable
    {
        public I Component { get; set; }

    }
}
