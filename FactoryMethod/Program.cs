using FactoryMethod;

Console.Title = "Factory Method";

IShapeFactory circleFactory = new CircleFactory();
IShapeFactory squareFactory = new SquareFactory();
IShapeFactory triangleFactory = new TriangleFactory();


IShape circle = circleFactory.CreateShape();
IShape square = squareFactory.CreateShape();
IShape triangle = triangleFactory.CreateShape();

List<IShape> shapes = new List<IShape>() { circle, square, triangle};

foreach (IShape shape in shapes)
{
    shape.Draw();
}

Console.ReadLine();