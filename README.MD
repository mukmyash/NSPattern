| ___develop___ |[![Build status](https://ci.appveyor.com/api/projects/status/9i1829duoa0rcsan/branch/develop?svg=true)](https://ci.appveyor.com/project/mukmyash/nspattern/branch/develop)|
|---|---|
|___master___|[![Build status](https://ci.appveyor.com/api/projects/status/9i1829duoa0rcsan/branch/master?svg=true)](https://ci.appveyor.com/project/mukmyash/nspattern/branch/master)|
# NSPattern
__Больше примеров в тестах__



***
Decorator Example
--------
Создайте интерфейс класса который необходимо затекорировать. Инерфейс должен наследоваться от ```IDecorateable```
```C#
	public interface IAnimal: IDecorateable
	{
		string SayHello();
	}
```

Создайте класс который реализует интерфейс из первого шага
```C#
	public class Duck : IAnimal
	{
		public string SayHello()
		{
			return "quack";
		}
	}
```

Создайте декоратор который реализует интерфейс ```IDecorator<I>``` и ```I``` (где ```I``` интерфейс созданный на первом шаге)
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


Использование:
```C#
	IAnimal duck = new Duck();
	var angryDuck = duck.Decorate(new AngryDecorator());

	var result = angryDucks.SayHello();

	Assert.Equal("QUACK!!!", result);

```


***
Repository Example
--------
Создайте класс который реализует интерфейс ```IRepository<T>```
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

Создайте классы спецификации. Например:
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


Использование:
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


***
Validate Repository Example
--------
Создайте декоратор для репозитория, который наследуется от ```RepositoryValidateDecoratorBase``` и реализует интерфейс декорируемого репозитория
(*в качестве примера репозиторий был взят из предыдущего примера*)
```C#
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
```

Использование:
```C#
	DataBase db = new DataBase();
	var test = new NSPattern.Test.Repository.Model.Repository(db);
	var testDecorate = test.Decorate(new RepositoryValidateDecorator());

	Assert.Throws<ArgumentNullException>(() =>
	{
	    testDecorate.Create(null);
	});

	Assert.Throws<ArgumentException>(() =>
	{
	    testDecorate.Create(new SampleEntity());
	});
```