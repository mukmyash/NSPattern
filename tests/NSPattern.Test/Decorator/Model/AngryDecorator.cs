using System;
using System.Collections.Generic;
using System.Text;
using NSPattern.Decorator;

namespace NSPattern.Test.Decorator.Model
{
    public class AngryDecorator : IDecorator<IAnimal>, IAnimal
    {
        public IAnimal Component { get; set; }

        public string SayHello()
        {
            return $"{Component.SayHello().ToUpper()}!!!";
        }
    }
}
