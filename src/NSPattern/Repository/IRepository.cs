using NSPattern.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSPattern.Repository
{
    public interface IRepository<T>
    {
        void Create(T entity);
        T GetById(long id);
        IList<T> GetList(ISpecification<T> specification, int offset, int count);
        bool CheckExists(ISpecification<T> specification);
        void Update(T entity);
    }
}
