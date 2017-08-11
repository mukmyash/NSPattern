using System;
using NSPattern.Decorator.Repository;
using NSPattern.Test.Repository.Model;

namespace NSPattern.Test.Decorator.Repository.Model
{
    public class RepositoryValidateDecorator
        : RepositoryValidateDecoratorBase<IRepository, SampleEntity>, IRepository
    {
        public override void Create_Before(SampleEntity entity)
        {
            if (string.IsNullOrEmpty(entity.sValue))
                throw new ArgumentException("Entity can't be null.", "entity.sValue");
        }
        public override void Create(SampleEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity", "Entity can't be null.");
            base.Create(entity);
        }

        public override void Update_Before(SampleEntity entity)
        {
            if (string.IsNullOrEmpty(entity.sValue))
                throw new ArgumentException("Entity can't be null.", "entity.sValue");
        }
        public override void Update(SampleEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity", "Entity can't be null.");
            base.Update(entity);
        }
    }
}