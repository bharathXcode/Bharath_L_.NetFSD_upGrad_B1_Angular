using System;
using System.Collections.Generic;
using System.Text;

class Account
{
    public int AccountNumber;
    public double Balance;

    public void CalculateInterest()
    {
        Console.WriteLine("Base account interest calculation");
    }
}

class SavingsAccount : Account
{
    public new void CalculateInterest()
    {
        Console.WriteLine("Savings Account Interest");
    }
}

class CurrentAccount : Account
{
    public new void CalculateInterest()
    {
        Console.WriteLine("Current Account Interest");
    }
}

class Q2_BankingMethodHiding
{
    static void Main()
    {
        Account acc = new SavingsAccount();
        acc.CalculateInterest(); // Method Hiding demo
    }
}