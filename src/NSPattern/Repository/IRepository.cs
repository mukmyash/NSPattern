using NSPattern.Specification.Expression;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSPattern.Repository
{
    public interface IRepository<T>
    {
        void Create(T entity);
        T GetById(long id);
        IList<T> GetList(ISpecificatinExpression<T> specification, int offset, int count);
        void Update(T entity);
    }
}
