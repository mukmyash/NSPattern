using NSPattern.Decorator;
using NSPattern.Repository;
using NSPattern.Test.Repository.Model;

namespace NSPattern.Test.Repository.Model
{
    public interface IRepository : IRepository<SampleEntity>, IDecorateable
    {

    }
}