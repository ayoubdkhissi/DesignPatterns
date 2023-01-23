namespace Facade;


// A subsystem class
public class OrderService
{
    public bool HasEnoughOrders(int customerId)
    {
        // fake calculation of the number of orders by a customer
        return customerId > 5;
    }
}

// A subsystem class
public class CustumerDiscountBaseService
{
    public double CalculateDiscountBase(int customerId)
    {
        // Fake calculation for demo purposes
        return (customerId > 8) ? 10 : 20;
    }
}

// A subsystem class
public class DayOfWeekFactorService
{
    public double CalculateDaysOfTheWeekFactor()
    {
        // fake calculation for demo purposes
        switch(DateTime.UtcNow.DayOfWeek)
        {
            case DayOfWeek.Sunday: return 0.25;
            case DayOfWeek.Friday: return 0.2;
            case DayOfWeek.Monday: return 0.15;
            default: return 0.3;
        }
    }
}

// The Facade class
public class DiscountFacade
{
    private readonly OrderService _orderService = new();
    private readonly CustumerDiscountBaseService _custumerDiscountBaseService = new();
    private readonly DayOfWeekFactorService _dayOfWeekFactorService = new();

    public double CalculateDiscountPercentage(int customerId)
    {
        if(!_orderService.HasEnoughOrders(customerId))
        {
            return 0;
        }

        return _custumerDiscountBaseService.CalculateDiscountBase(customerId)
            * _dayOfWeekFactorService.CalculateDaysOfTheWeekFactor();
    }
}
