using NSPattern.Test.Decorator.Model;
using NSPattern.Decorator;
using Xunit;
using NSPattern.Test.Repository.Model;
using NSPattern.Test.Decorator.Repository.Model;
using System;

namespace NSPattern.Test.Decorator.Repository
{
    public class RepositoryValidateDecoratorBaseUnitTest
    {
        [Fact]
        public void CheckValidateDecorate()
        {
            DataBase db = new DataBase();
            var test = new NSPattern.Test.Repository.Model.Repository(db);
            var testDecorate = test.Decorate(new RepositoryValidateDecorator());

            Assert.Throws<ArgumentNullException>(() =>
            {
                testDecorate.Create(null);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                testDecorate.Create(new SampleEntity());
            });
        }
    }
}
