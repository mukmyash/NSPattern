using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace NSPattern.Specification.Classic
{
    internal class OrSpecification<T> : SpecificationBase<T>
    {
        private readonly SpecificationBase<T> _left;
        private readonly SpecificationBase<T> _right;

        public OrSpecification(SpecificationBase<T> left, SpecificationBase<T> right)
        {
            _right = right;
            _left = left;
        }

        public override bool IsSatisfiedBy(T entity)
        {
            return _left.IsSatisfiedBy(entity) || _right.IsSatisfiedBy(entity);
        }
    }
}
