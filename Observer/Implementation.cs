namespace Observer;

public class TicketChange
{
    public int Amount { get; private set; }
    public int ArtistId { get; private set; }

    public TicketChange(int amount, int artistId)
    {
        Amount = amount;
        ArtistId = artistId;
    }
}

public interface ITicketChangeListener
{
    void ReceiveTicketChangeNotification(TicketChange ticketChange);
    
}


public abstract class TicketChangeNotifier
{
    private List<ITicketChangeListener> _observers = new();

    public void AddObserver(ITicketChangeListener observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(ITicketChangeListener observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers(TicketChange ticketChange)
    {
        foreach (var observer in _observers)
        {
            observer.ReceiveTicketChangeNotification(ticketChange);
        }
    }
}

public class OrderService : TicketChangeNotifier
{
    // method that represents a change of state
    public void CompleteTicketSale(int amount, int artistId)
    {
        // changing state
        Console.WriteLine("The order service is changing its state");

        // notify subscribers
        this.NotifyObservers(new TicketChange(amount, artistId));
    }
}

public class TicketResellerService : ITicketChangeListener
{
    public void ReceiveTicketChangeNotification(TicketChange ticketChange)
    {
        Console.WriteLine($"Ticker Reseller Received notification with state" +
            $"artistId: {ticketChange.ArtistId}, Amount: {ticketChange.Amount}");
    }
}
public class TicketStockService : ITicketChangeListener
{
    public void ReceiveTicketChangeNotification(TicketChange ticketChange)
    {
        Console.WriteLine($"Ticker Stock Received notification with state" +
            $"artistId: {ticketChange.ArtistId}, Amount: {ticketChange.Amount}");
    }
}

