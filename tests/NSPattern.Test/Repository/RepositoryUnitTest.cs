using NSPattern.Test.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace NSPattern.Test.Repository
{
    public class RepositoryUnitTest
    {
        [Fact]
        public void SampleUseRepositoryCreate()
        {
            DataBase db = new DataBase();
            var rep = new Repository.Model.Repository(db);
            var entity = new SampleEntity()
            {
                id = 0,
                iValue = 1,
                mValue = 1m,
                sValue = "1"
            };
            rep.Create(entity);


            Assert.Equal(1, entity.id);
            Assert.Equal(1, db.Samples.Count);
            Assert.Equal(entity, db.Samples.First());
        }

        [Fact]
        public void SampleUseRepositoryUpdate()
        {
            var db = GetMockDB();
            var rep = new Repository.Model.Repository(db);
            var entity = new SampleEntity()
            {
                id = 1,
                iValue = 2,
                mValue = 2m,
                sValue = "2"
            };
            rep.Update(entity);


            Assert.Equal(3, db.Samples.Count);
            Assert.Equal(entity, db.Samples.First(n => n.id == 1));
        }

        [Fact]
        public void SampleUseRepositoryGetById()
        {
            var db = GetMockDB();
            var rep = new Repository.Model.Repository(db);
            var result = rep.GetById(1);

            var entity = new SampleEntity()
            {
                id = 1,
                iValue = 1,
                mValue = 1m,
                sValue = "1"
            };
            Assert.Equal(3, db.Samples.Count);
            Assert.Equal(entity, result);
        }

        [Fact]
        public void SampleUseRepositoryGetList()
        {
            var db = GetMockDB();
            var rep = new Repository.Model.Repository(db);
            var result = rep.GetList(new iValueRangeSpecification(2, 3), 0, 10);

            Assert.Equal(2, result.Count);
            Assert.False(result.Any(n => 2 > n.iValue && n.iValue > 3));
        }

        [Fact]
        public void SampleUseRepositoryGetList_ANDSpecification()
        {
            var db = GetMockDB();
            var rep = new Repository.Model.Repository(db);
            var spec = new iValueRangeSpecification(2, 3).And(new sValueContainsSpecification("2"));
            var result = rep.GetList(spec, 0, 10);

            Assert.Equal(1, result.Count);
            Assert.False(result.Any(n => 2 > n.iValue && n.iValue > 3));
            Assert.True(result.Any(n => n.sValue.Contains("2")));
        }

        [Fact]
        public void SampleUseRepositoryGetList_ORSpecification()
        {
            var db = GetMockDB();
            var rep = new Repository.Model.Repository(db);
            var spec = new iValueRangeSpecification(2, 3).Or(new sValueContainsSpecification("1"));
            var result = rep.GetList(spec, 0, 10);

            Assert.Equal(3, result.Count);
            Assert.True(result.Any(n => 2 <= n.iValue && n.iValue <= 3));
            Assert.True(result.Any(n => n.sValue.Contains("1")));
        }

        private DataBase GetMockDB()
        {
            return new DataBase()
            {
                Samples = new List<SampleEntity>()
                {
                    new SampleEntity()
                    {
                        id = 1,
                        iValue = 1,
                        mValue = 1m,
                        sValue = "1"
                    }
                    ,new SampleEntity()
                    {
                        id = 2,
                        iValue = 2,
                        mValue = 2m,
                        sValue = "2"
                    }
                    ,new SampleEntity()
                    {
                        id = 3,
                        iValue = 3,
                        mValue = 3m,
                        sValue = "3"
                    }
                }
            };
        }
    }
}
