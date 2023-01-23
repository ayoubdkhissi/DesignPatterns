using Bridge;

Console.Title = "Bridge";

ICoupon noCoupon = new NoCoupon();
ICoupon oneEuroCoupon = new OneEuroCoupon();

Menu meatMenuWithNoCoupon = new MeatMenu(noCoupon);
Menu meatMenuWithOneEuroCoupon = new MeatMenu(oneEuroCoupon);

Console
    .WriteLine($"Price of meat menu with no coupon: {meatMenuWithNoCoupon.CalculatePrice()}");
Console
    .WriteLine($"Price of meat menu with one euro coupon: {meatMenuWithOneEuroCoupon.CalculatePrice()}");