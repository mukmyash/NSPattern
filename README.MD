# NSPattern


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