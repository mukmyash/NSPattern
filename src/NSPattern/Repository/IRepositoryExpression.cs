using NSPattern.Specification;
using System;
using System.Collections.Generic;
using System.Text;
using NSPattern.Decorator;
using NSPattern.Specification.Expression;

namespace NSPattern.Repository
{
    public interface IRepositoryExpression<T> 
    {
        void Create(T entity);
        T GetById(long id);
        IList<T> GetList(ISpecificationExpression<T> specification, int offset, int count);
        void Update(T entity);
    }
}
