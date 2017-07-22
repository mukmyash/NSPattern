using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NSPattern.Specification.Classic
{
    internal class AndSpecification<T> : SpecificationBase<T>
    {
        private readonly SpecificationBase<T> _left;
        private readonly SpecificationBase<T> _right;

        public AndSpecification(SpecificationBase<T> left, SpecificationBase<T> right)
        {
            _right = right;
            _left = left;
        }

        public override bool IsSatisfiedBy(T entity)
        {
            return _left.IsSatisfiedBy(entity) && _right.IsSatisfiedBy(entity);
        }
    }
}
