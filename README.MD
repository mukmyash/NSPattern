[![Build status](https://ci.appveyor.com/api/projects/status/9i1829duoa0rcsan/branch/develop?svg=true)](https://ci.appveyor.com/project/mukmyash/nspattern/branch/develop)
# NSPattern
__More sample in tests__

Decorator Example
--------
Create interface and implements from ```IDecorateable```
```C#
	public interface IAnimal: IDecorateable
	{
		string SayHello();
	}
```

Create class and implements interface created on previus step
```C#
	public class Duck : IAnimal
	{
		public string SayHello()
		{
			return "quack";
		}
	}
```

Create decorators and implements ```IDecorator<I>``` and ```I``` (where ```I``` is interface created on first step)
```C#
	public class AngryDecorator : IDecorator<IAnimal>, IAnimal
	{
		public IAnimal Component { get; set; }

		public string SayHello()
		{
			return $"{Component.SayHello().ToUpper()}!!!";
		}
	}
```


Use
```C#
	IAnimal duck = new Duck();
	var angryDuck = duck.Decorate(new AngryDecorator());

	var result = angryDucks.SayHello();

	Assert.Equal("QUACK!!!", result);

```


Repository Example
--------
Create interface implementation from ```IRepository<T>```
```C#
	public class Repository : IRepository<SampleEntity>
	{
		
		public void Create(SampleEntity entity)
		{
			/// Logic 
		}
		
		public SampleEntity GetById(long id)
		{
			/// Logic 
		}
		
		public IList<SampleEntity> GetList(ISpecification<SampleEntity> specification, int offset, int count)
		{
			/// Logic
		}
		
		public void Update(SampleEntity entity)
		{
			/// Logic
		}
	}
```

Create class specification
```C#
	public class iValueRangeSpecification : SpecificationBase<SampleEntity>
	{
		public int Min { get; private set; }
		public int Max { get; private set; }
		public iValueRangeSpecification(int min, int max)
		{
			Min = min;
			Max = max;
		}
		public override Expression<Func<SampleEntity, bool>> ToExpression()
		{
			return n => Min <= n.iValue && n.iValue <= Max;
		}
	}
```


Use
```C#
	DbContext db = new DbContext();
	var rep = new Repository.Model.Repository(db);
	var entity = new SampleEntity()
	{
	    id = 0,
	    iValue = 1,
	    mValue = 1m,
	    sValue = "1"
	};
	/// Add object to collection\DataBase
	rep.Create(entity);
	
	/// Get object by id;
	var result = rep.GetById(1);
	result.iValue = 2;
	
	/// Update object in collection\database
	rep.Update(entity);
	
	/// Get objects from collection\database by rule
	var resultList = rep.GetList(new iValueRangeSpecification(2, 3), 0, 10);
```