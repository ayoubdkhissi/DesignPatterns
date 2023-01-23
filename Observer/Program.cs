using Observer;

Console.Title = "Observer";

// observers
TicketStockService ticketStockService1 = new ();
TicketStockService ticketStockService2 = new ();
TicketResellerService ticketResellerService = new ();

// subject
OrderService orderService = new OrderService ();

// registering observers
orderService.AddObserver(ticketStockService1);
orderService.AddObserver(ticketResellerService);

// changing state of the subject
orderService.CompleteTicketSale(0, 15);
