using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NSPattern.Specification.Classic
{
    public abstract class SpecificationBase<TEntity>: ISpecification<TEntity>
    {
        public abstract bool IsSatisfiedBy(TEntity entity);

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
