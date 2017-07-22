using System;
using System.Collections.Generic;
using System.Text;

namespace NSPattern.Test.Decorator.Model
{
    public class Duck : IAnimal
    {
        public string SayHello()
        {
            return "quack";
        }
    }
}
