using System;
using System.Collections.Generic;
using System.Text;

// Custom Exception
class CheckBalanceException : Exception
{
    public CheckBalanceException(string message) : base(message) { }
}

// Bank Account Class
class BankAccount
{
    public int AccountNumber { get; set; }
    public string Name { get; set; }
    public static double Balance;
    public char TransactionType;
    public double TransactionAmount;

    public BankAccount(int accNo, string name, double balance)
    {
        AccountNumber = accNo;
        Name = name;
        Balance = balance;
    }

    public void PerformTransaction(char type, double amount)
    {
        TransactionType = type;
        TransactionAmount = amount;

        if (type == 'd') // deposit
        {
            Balance += amount;
            Console.WriteLine("Amount Deposited Successfully");
        }
        else if (type == 'c') // withdrawal
        {
            if (Balance - amount < 500)
            {
                throw new CheckBalanceException("Insufficient Balance! Minimum balance should be 500");
            }
            else
            {
                Balance -= amount;
                Console.WriteLine("Amount Withdrawn Successfully");
            }
        }
    }

    public void Display()
    {
        Console.WriteLine("Account Number: " + AccountNumber);
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Balance: " + Balance);
    }
}

// ------------------- MAIN -------------------
class Q1_BankAccountExceptionHandling
{
    static void Main()
    {
        try
        {
            BankAccount acc = new BankAccount(101, "Bharath", 1000);

            acc.Display();

            Console.Write("Enter transaction type (d/c): ");
            char type = Convert.ToChar(Console.ReadLine());

            Console.Write("Enter amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            acc.PerformTransaction(type, amount);

            acc.Display();
        }
        catch (CheckBalanceException ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("General Exception: " + ex.Message);
        }
    }
}
