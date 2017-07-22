using System;
using System.Collections.Generic;
using System.Text;
using NSPattern.Decorator;

namespace NSPattern.Test.Decorator.Model
{
    public interface IAnimal : IDecorateable
    {
        string SayHello();
    }
}
