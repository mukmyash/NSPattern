using NSPattern.Specification.Expression;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace NSPattern.Test.Repository.Model
{
    public class iValueRangeSpecification : SpecificationBase<SampleEntity>
    {
        public int Min { get; private set; }
        public int Max { get; private set; }
        public iValueRangeSpecification(int min, int max)
        {
            Min = min;
            Max = max;
        }
        public override Expression<Func<SampleEntity, bool>> ToExpression()
        {
            return n => Min <= n.iValue && n.iValue <= Max;
        }
    }
}
