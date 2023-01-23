namespace State;

public abstract class BankAccountState
{
    public BankAccount Account { get; protected set; } = null!;

    public decimal Balance { get; protected set; }
    public abstract void Deposit(decimal amount);
    public abstract void Withdraw(decimal amount);
}

// The context
public class BankAccount
{
    public BankAccountState State { get; set; }

    public decimal Balance { get { return State.Balance; } }

    public BankAccount(decimal balance)
    {
        State = new RegularState(balance, this);
    }

    public void Deposit(decimal amount)
    {
        State.Deposit(amount);
    }

    public void Withdraw(decimal amount)
    {
        State.Withdraw(amount);
    }
}

// Concrete state
public class OverdrawnState : BankAccountState
{
    public OverdrawnState(decimal balance, BankAccount bankAccount)
    {
        this.Balance = balance;
        this.Account = bankAccount;
    }

    public override void Deposit(decimal amount)
    {
        Console.WriteLine($"Depositing {amount}$, in {GetType()}");
        Balance += amount;
        if(Balance > 0 && Balance <1000)
        {
            Console.WriteLine("Account goes to normal state after operation");
            this.Account.State = new RegularState(Balance, Account);
            return;
        }
        if (Balance >= 1000)
        {
            Console.WriteLine("Account goes to gold state after operation");
            this.Account.State = new GoldState(Balance, Account);
        }
    }

    public override void Withdraw(decimal amount)
    {
        Console.WriteLine($"attempt withdrawing {amount} in {GetType()}, but Forbidden, account is overdrawn");
    }
}

public class RegularState : BankAccountState
{
    public RegularState(decimal balance, BankAccount bankAccount)
    {
        this.Balance = balance;
        this.Account = bankAccount;
    }

    public override void Deposit(decimal amount)
    {
        Console.WriteLine($"Depositing {amount}$, in {GetType()}");
        Balance += amount;
        if(Balance >= 1000)
        {
            Console.WriteLine("Transition to GOLD state");
            this.Account.State = new GoldState(Balance, Account);
        }
    }

    public override void Withdraw(decimal amount)
    {
        Console.WriteLine($"Withdrawing {amount}$, in {GetType()}");
        Balance -= amount;
        
        if(Balance < 0)
        {
            // changing state of the account to overdrawn
            Console.WriteLine("Account goes to overdrawn state after operation");
            this.Account.State = new OverdrawnState(Balance, Account);
        }
    }
}


public class GoldState : BankAccountState
{
    public GoldState(decimal balance, BankAccount bankAccount)
    {
        this.Balance = balance;
        this.Account = bankAccount;
    }

    public override void Deposit(decimal amount)
    {
        Console.WriteLine($"Depositing {amount}$, in {GetType()}, + bonus {amount/10}$");
        Balance += amount + amount/10;
    }

    public override void Withdraw(decimal amount)
    {
        Console.WriteLine($"Withdrawing {amount}$, in {GetType()}");
        Balance -= amount;
        if (Balance < 1000 && Balance >= 0)
        {
            this.Account.State = new RegularState(Balance, Account);
            return;
        }
        if (Balance < 0)
        {
            this.Account.State = new OverdrawnState(Balance, Account);
        }
    }
}