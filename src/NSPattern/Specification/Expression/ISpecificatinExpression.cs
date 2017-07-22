using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NSPattern.Specification.Expression
{
    public interface ISpecificatinExpression<TEntity> : ISpecification<TEntity>
    {
        Expression<Func<TEntity, bool>> ToExpression();
    }
}
