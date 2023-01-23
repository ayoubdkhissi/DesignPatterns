using AbstractFactory;

Console.Title = "Abstract Factory";

IShapeFactory circleFactory = new CircleFactory();
IShapeFactory squareFactory = new SquareFactory();

IShape coloredSquare = squareFactory.CreateColoredShape();
IShape emptySquare = squareFactory.CreateEmptyShape();
IShape coloredCircle = circleFactory.CreateColoredShape();
IShape emptyCircle = circleFactory.CreateEmptyShape();

List<IShape> shapes = new List<IShape>() 
{ 
    coloredSquare, 
    emptySquare, 
    coloredCircle, 
    emptyCircle
};

foreach (IShape shape in shapes)
{
    shape.Draw();
}

Console.ReadLine();