using Decorator;

Console.Title = "Decorator";

// instantiate mail services
var cloudMailService = new CloudMailService();
cloudMailService.SendEmail("Hello there!");

var onPremiseMailService = new OnPremiseMailService();
onPremiseMailService.SendEmail("Hello there!");

// adding functionality to the cloud mail service
var statisticsDecorator = new StatisticsMailDecorator(cloudMailService);
statisticsDecorator.SendEmail($"Hello there by {nameof(StatisticsMailDecorator)} decorator!");