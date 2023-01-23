using System.Text.Json;
using System.Xml.Serialization;

namespace Strategy;

public interface IExportService
{
    void Export(Order order);
}

public class Order
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public DateTime Created { get; set; }

    public Order(int id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
        Created = DateTime.Now;
    }

    public Order()
    {
    }

    public void Export(IExportService exportService)
    {
        exportService.Export(this);
    }

}


public class JsonExportService : IExportService
{
    public void Export(Order order)
    {
        string jsonOrder = JsonSerializer.Serialize(order);
        Console.WriteLine($"Exporting order as Json : \n{jsonOrder}");
    }
}

public class XmlExportService : IExportService
{
    public void Export(Order order)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Order));
        using (StringWriter stringWriter = new StringWriter())
        {
            serializer.Serialize(stringWriter, order);
            string xmlString = stringWriter.ToString();
            Console.WriteLine($"Exporting the order as XML: \n {xmlString}");
        }
    }
}
