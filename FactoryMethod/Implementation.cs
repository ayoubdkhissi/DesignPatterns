namespace FactoryMethod;

public interface IShape
{
    public void Draw();
}

public class Circle: IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Circle");
    }
}

public class Square : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Square");
    }
}

public class Triangle : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Triangle");
    }
}

public interface IShapeFactory
{
    // this is the factory method
    public IShape CreateShape();
}

public class CircleFactory : IShapeFactory
{
    public IShape CreateShape()
    {
        return new Circle();   
    }
}


public class SquareFactory : IShapeFactory
{
    public IShape CreateShape()
    {
        return new Square();
    }
}


public class TriangleFactory : IShapeFactory
{
    public IShape CreateShape()
    {
        return new Triangle();
    }
}