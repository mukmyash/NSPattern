using NSPattern.Specification.Expression;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace NSPattern.Test.Repository.Model
{
    public class sValueContainsSpecification : SpecificationBase<SampleEntity>
    {
        public string Value { get; private set; }
        public sValueContainsSpecification(string value)
        {
            Value = value;
        }
        public override Expression<Func<SampleEntity, bool>> ToExpression()
        {
            return n => n.sValue.Contains(Value);
        }
    }
}
