using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NSPattern.Specification.Expression
{
    public class AndSpecification<T> : SpecificationBase<T>
    {
        private readonly SpecificationBase<T> _left;
        private readonly SpecificationBase<T> _right;

        public AndSpecification(SpecificationBase<T> left, SpecificationBase<T> right)
        {
            _right = right;
            _left = left;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            Expression<Func<T, bool>> leftExpression = _left.ToExpression();
            Expression<Func<T, bool>> rightExpression = _right.ToExpression();

            BinaryExpression andExpression = System.Linq.Expressions.Expression.AndAlso(
                leftExpression.Body, rightExpression.Body);

            return System.Linq.Expressions.Expression.Lambda<Func<T, bool>>(
                andExpression, leftExpression.Parameters.Single());
        }
    }
}
