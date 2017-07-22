using NSPattern.Decorator;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSPattern.Test.Decorator.Model
{
    public class FirstDecorator : IDecorator<IAnimal>, IAnimal
    {
        public IAnimal Component { get; set; }

        public string SayHello()
        {
            return $"{Component.SayHello()}1";
        }
    }
}
