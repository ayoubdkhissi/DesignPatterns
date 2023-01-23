using Prototype;

Console.Title = "Prototype";

// Shallow copy test
Manager manager = new Manager("AYOUB");
Employee employee = new Employee("Chaymae", manager);

Employee employeeClone = (Employee)employee.Clone(true);

// changing manager name

manager.Name = "ALI";

Console.WriteLine($"Name of Manager : {manager.Name}");
Console.WriteLine($"Name of employee clone manager: {employeeClone.Manager.Name}");

Console.ReadKey();