using NSPattern.Test.Decorator.Model;
using NSPattern.Decorator;
using Xunit;

namespace NSPattern.Test.Decorator
{
    public class IDecorateableExtensionsUnitTest
    {
        [Fact]
        public void CheckDecorate()
        {
            IAnimal test = new Duck();
            var testDecorate = test.Decorate(new AngryDecorator());

            var result = testDecorate.SayHello();

            Assert.Equal("QUACK!!!", result);
        }
    }
}
