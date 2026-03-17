using System;

 
class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message) : base(message)
    {
    }
}

// Bank Account Class
class BankAccount
{
    private double balance;

    
    public BankAccount(double balance)
    {
        this.balance = balance;
    }

    
    public void Withdraw(double amount)
    {
        if (amount > balance)
        {
            // Throw custom exception
            throw new InsufficientBalanceException("Withdrawal amount exceeds available balance");
        }
        else
        {
            balance -= amount;
            Console.WriteLine("Withdrawal Successful! Remaining Balance: " + balance);
        }
    }
}

 
class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Enter Balance: ");
            double balance = double.Parse(Console.ReadLine());

            Console.Write("Enter Withdrawal Amount: ");
            double amount = double.Parse(Console.ReadLine());

            BankAccount account = new BankAccount(balance);
            account.Withdraw(amount);
        }
        catch (InsufficientBalanceException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Invalid input!");
        }
        finally
        {
            Console.WriteLine("Transaction completed.");
        }

        Console.WriteLine("Program continues...");
    }
}
