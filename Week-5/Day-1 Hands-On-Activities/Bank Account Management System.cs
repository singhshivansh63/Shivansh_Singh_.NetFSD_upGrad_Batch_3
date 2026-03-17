using System;

class BankAccount
{
    // Private fields (Data Hiding)
    private int accountNumber;
    private double balance;

    // Property for Account Number
    public int AccountNumber
    {
        get { return accountNumber; }
        set { accountNumber = value; }
    }

    // Property for Balance (Read Only outside class)
    public double Balance
    {
        get { return balance; }
    }

    // Method to Deposit Money
    public void Deposit(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Invalid deposit amount.");
        }
        else
        {
            balance = balance + amount;
            Console.WriteLine("Amount Deposited: " + amount);
            Console.WriteLine("Updated Balance: " + balance);
        }
    }

    // Method to Withdraw Money
    public void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Invalid withdrawal amount.");
        }
        else if (amount > balance)
        {
            Console.WriteLine("Insufficient Balance.");
        }
        else
        {
            balance = balance - amount;
            Console.WriteLine("Amount Withdrawn: " + amount);
            Console.WriteLine("Updated Balance: " + balance);
        }
    }
}

class Program
{
    static void Main()
    {
        BankAccount acc = new BankAccount();

        // Assign account number
        acc.AccountNumber = 101;

        // Sample transactions
        acc.Deposit(5000);
        acc.Withdraw(2000);

        Console.WriteLine("Current Balance = " + acc.Balance);
    }
}