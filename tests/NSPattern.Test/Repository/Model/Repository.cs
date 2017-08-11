using NSPattern.Repository;
using NSPattern.Specification;
using NSPattern.Specification.Expression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSPattern.Decorator;

namespace NSPattern.Test.Repository.Model
{
    public class Repository : IRepository
    {
        public DataBase DB { get; set; }

        public Repository(DataBase db)
        {
            DB = db;
        }

        public void Create(SampleEntity entity)
        {
            var nextId = DB.Samples.Count + 1;
            entity.id = nextId;
            DB.Samples.Add(entity);
        }

        public SampleEntity GetById(long id)
        {
            return DB.Samples.Single(n => n.id == id);
        }

        public IList<SampleEntity> GetList(ISpecification<SampleEntity> specification, int offset, int count)
        {
            var specificationExpression = specification as ISpecificationExpression<SampleEntity>;
            return DB.Samples.Where(specificationExpression.ToExpression().Compile())
                .Skip(offset).Take(count).ToList();
        }

        public void Update(SampleEntity entity)
        {
            var updateEntity = DB.Samples.Single(n => n.id == entity.id);

            updateEntity.iValue = entity.iValue;
            updateEntity.mValue = entity.mValue;
            updateEntity.sValue = entity.sValue;
        }
    }
}
