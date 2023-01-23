namespace Visitor;

public abstract class Item
{
    public double Price { get; set; }
    public abstract void Accept(IVisitor visitor);

    protected Item(double price)
    {
        Price = price;
    }
}

public interface IVisitor
{
    void Visit(Shirt item);
    void Visit(Pants item);
    void Visit(Shoes item);
}

public class TaxVisitor : IVisitor
{
    public double Tax { get; set; } = 0;
    
    public void Visit(Shirt item)
    {
        Console.WriteLine($"Visiting {item.GetType()}, applying tax {item.Price * 0.025}");
        Tax += item.Price * 0.025;
    }
    public void Visit(Pants item)
    {
        Console.WriteLine($"Visiting {item.GetType()}, applying tax {item.Price * 0.050}");
        Tax += item.Price * 0.050;
    }
    public void Visit(Shoes item)
    {
        Console.WriteLine($"Visiting {item.GetType()}, applying tax {item.Price * 0.075}");
        Tax += item.Price * 0.075;
    }
}

public class DiscountVisitor : IVisitor
{
    public double Discount { get; set; } = 0;
    public void Visit(Shirt item)
    {
        Console.WriteLine($"Visiting {item.GetType()}, applying discount {10}");
        Discount += 10;
    }

    public void Visit(Pants item)
    {
        Console.WriteLine($"Visiting {item.GetType()}, applying discount {7}");
        Discount += 7;
    }

    public void Visit(Shoes item)
    {
        Console.WriteLine($"Visiting {item.GetType()}, applying discount {5}");
        Discount += 5;
    }
}
public class Pants : Item
{
    public Pants(double price) : base(price){}
    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);   
    }
}






public class Shoes : Item
{
    public Shoes(double price) : base(price){}

    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class Shirt : Item
{
    public Shirt(double price) : base(price){}
    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}




public class ShoppingCart
{
    private List<Item> _items = new List<Item>();
    
    // add item
    public void AddItem(Item item)
    {
        _items.Add(item);
    }

    public double CalculateTax()
    {
        TaxVisitor taxVisitor = new();
        foreach(Item item in _items)
        {
            item.Accept(taxVisitor);
        }
        return taxVisitor.Tax;
    }

    public double CaculateDiscount()
    {
        DiscountVisitor discountVisitor = new();
        foreach (Item item in _items)
        {
            item.Accept(discountVisitor);
        }
        return discountVisitor.Discount;
    }
}

