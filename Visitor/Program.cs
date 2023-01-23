using Visitor;

Console.Title = "Visitor";

// Create a shopping cart
var cart = new ShoppingCart();

// add different items
cart.AddItem(new Shirt(100));
cart.AddItem(new Pants(200));
cart.AddItem(new Shoes(300));
cart.AddItem(new Shirt(100));

Console.WriteLine($"Total Tax is : {cart.CalculateTax()} $");
Console.WriteLine($"Total Discount is : {cart.CaculateDiscount()}");
