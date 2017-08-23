using System;
using System.Collections.Generic;
using NSPattern.Repository;
using NSPattern.Specification;
using NSPattern.Specification.Expression;

namespace NSPattern.Decorator.Repository
{
    public abstract class RepositoryExpressionValidateDecoratorBase<TRepository, TEntity>
    : DecoratorBase<TRepository>, IRepositoryExpression<TEntity>
    where TRepository : IDecorateable, IRepositoryExpression<TEntity>
    {
        public virtual void Create_Before(TEntity entity) { }
        public virtual void Create(TEntity entity)
        {
            Create_Before(entity);
            Component.Create(entity);
            Create_After(entity);
        }
        public virtual void Create_After(TEntity entity) { }


        public virtual void GetById_Before(long id) { }
        public virtual TEntity GetById(long id)
        {
            GetById_Before(id);
            var result = Component.GetById(id);
            GetById_After(id, result);
            return result;
        }
        public virtual void GetById_After(long id, TEntity result) { }

        public virtual void GetList_Before(ISpecificationExpression<TEntity> specification, int offset, int count) { }
        public virtual IList<TEntity> GetList(ISpecificationExpression<TEntity> specification, int offset, int count)
        {
            GetList_Before(specification, offset, count);
            var result = Component.GetList(specification, offset, count);
            GetList_After(specification, offset, count, result);
            return result;
        }
        public virtual void GetList_After(ISpecificationExpression<TEntity> specification, int offset, int count, IList<TEntity> result) { }


        public virtual void Update_Before(TEntity entity) { }
        public virtual void Update(TEntity entity)
        {
            Update_Before(entity);
            Component.Update(entity);
            Update_After(entity);
        }
        public virtual void Update_After(TEntity entity) { }

        public virtual void CheckExists_Before(ISpecificationExpression<TEntity> specification) { }
        public virtual bool CheckExists(ISpecificationExpression<TEntity> specification)
        {
            CheckExists_Before(specification);
            var result = Component.CheckExists(specification);
            CheckExists_After(specification, result);
            return result;
        }
        public virtual void CheckExists_After(ISpecificationExpression<TEntity> specification, bool result) { }
    }
}