using Strategy;

Console.Title = "Strategy";

Order order = new Order(1, "IPhone X", 10000);
order.Export(new JsonExportService());
Console.WriteLine();
order.Export(new XmlExportService());


