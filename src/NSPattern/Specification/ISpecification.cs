using System;
using System.Collections.Generic;
using System.Text;

namespace NSPattern.Specification
{
    public interface ISpecification<TEntity>
    {
        bool IsSatisfiedBy(TEntity entity);
    }
}
