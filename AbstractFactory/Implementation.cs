namespace AbstractFactory;


public interface IShape
{
    public void Draw();
}

public interface IColoredShape : IShape
{
    // some properties or methods specific to Colored shapes
}

public interface IEmptyShape : IShape
{
    // some properties or methods specific to Empty shapes
}

public class ColoredSquare : IColoredShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a colored Square");
    }
}

public class ColoredCircle : IColoredShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a colored Circle");
    }
}

public class EmptySquare : IEmptyShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing an Empty Square");
    }
}

public class EmptyCircle : IEmptyShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing an Empty Circle");
    }
}

public interface IShapeFactory
{
    IColoredShape CreateColoredShape();
    IEmptyShape CreateEmptyShape();
}

public class SquareFactory : IShapeFactory
{
    public IColoredShape CreateColoredShape()
    {
        return new ColoredSquare();
    }
    public IEmptyShape CreateEmptyShape()
    {
        return new EmptySquare();
    }
}

public class CircleFactory : IShapeFactory
{
    public IColoredShape CreateColoredShape()
    {
        return new ColoredCircle();
    }
    public IEmptyShape CreateEmptyShape()
    {
        return new EmptyCircle();
    }
}
