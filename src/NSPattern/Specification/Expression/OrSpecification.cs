using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace NSPattern.Specification.Expression
{
    public class OrSpecification<T> : SpecificationBase<T>
    {
        private readonly SpecificationBase<T> _left;
        private readonly SpecificationBase<T> _right;

        public OrSpecification(SpecificationBase<T> left, SpecificationBase<T> right)
        {
            _right = right;
            _left = left;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            Expression<Func<T, bool>> leftExpression = _left.ToExpression();
            Expression<Func<T, bool>> rightExpression = _right.ToExpression();

            BinaryExpression andExpression = System.Linq.Expressions.Expression.Or(
                leftExpression.Body, rightExpression.Body);

            var paramExpr = System.Linq.Expressions.Expression.Parameter(typeof(T));
            andExpression = (BinaryExpression) new ParameterReplacer(paramExpr).Visit(andExpression);

            return System.Linq.Expressions.Expression.Lambda<Func<T, bool>>(
                andExpression, paramExpr);
        }
    }
}
