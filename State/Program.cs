using State;

Console.Title = "State";


BankAccount bankAccount = new BankAccount(200);

bankAccount.Deposit(810); // account goes to Gold state
bankAccount.Deposit(100); // get a bonus of 10%
bankAccount.Withdraw(220); // account goes back to regular state
bankAccount.Withdraw(1000); // account is overdrawn
bankAccount.Deposit(500); // account goes to normal state