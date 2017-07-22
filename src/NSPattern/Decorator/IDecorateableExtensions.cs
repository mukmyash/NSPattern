using System;
using System.Collections.Generic;
using System.Text;

namespace NSPattern.Decorator
{
    public static class IDecorateableExtensions
    {
        public static I Decorate<I>(this I instance, params IDecorator<I>[] decorators)
            where I : IDecorateable
        {
            I result = instance;
            foreach (var decorator in decorators)
            {
                decorator.Component = result;
                result = (I)decorator;
            }
            return result;
        }
    }
}
