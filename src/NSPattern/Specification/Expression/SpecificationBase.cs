using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NSPattern.Specification.Expression
{
    public abstract class SpecificationBase<TEntity> : ISpecificatinExpression<TEntity>
    {
        Func<TEntity, bool> predicate;
        public abstract Expression<Func<TEntity, bool>> ToExpression();

        public bool IsSatisfiedBy(TEntity entity)
        {
            if (predicate == null)
                predicate = this.ToExpression().Compile();
            return predicate(entity);
        }

        public SpecificationBase<TEntity> And(SpecificationBase<TEntity> specification)
        {
            return new AndSpecification<TEntity>(this, specification);
        }
        public SpecificationBase<TEntity> Or(SpecificationBase<TEntity> specification)
        {
            return new OrSpecification<TEntity>(this, specification);
        }
    }
}
