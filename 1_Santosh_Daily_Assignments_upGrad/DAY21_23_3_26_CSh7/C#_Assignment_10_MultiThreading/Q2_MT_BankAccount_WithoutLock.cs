using System;
using System.Threading;

// Q2 - Bank Account WITHOUT synchronization (Problem demonstration)
class Q2_MT_BankAccount_WithoutLock
{
    class BankAccount
    {
        public int Balance = 1000;

        // Withdraw method WITHOUT lock (unsafe)
        public void Withdraw(int amount)
        {
            if (Balance >= amount)
            {
                Console.WriteLine($"Withdrawing {amount}...");

                // Simulate delay (causes race condition)
                Thread.Sleep(500);

                Balance -= amount;

                Console.WriteLine($"Remaining Balance: {Balance}");
            }
            else
            {
                Console.WriteLine("Insufficient Balance!");
            }
        }
    }

    static void Main(string[] args)
    {
        BankAccount account = new BankAccount();

        // 3 threads trying to withdraw simultaneously
        Thread t1 = new Thread(() => account.Withdraw(500));
        Thread t2 = new Thread(() => account.Withdraw(500));
        Thread t3 = new Thread(() => account.Withdraw(500));

        t1.Start();
        t2.Start();
        t3.Start();

        t1.Join();
        t2.Join();
        t3.Join();

        Console.WriteLine($"Final Balance: {account.Balance}");
    }
}
