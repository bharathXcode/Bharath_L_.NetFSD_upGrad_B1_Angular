using System;
using System.Threading;

// Q2 - Bank Account WITH synchronization using lock
class Q2_MT_BankAccount_WithLock
{
    class BankAccount
    {
        public int Balance = 1000;

        // Lock object for synchronization
        private object lockObj = new object();

        // Thread-safe withdraw method
        public void Withdraw(int amount)
        {
            lock (lockObj) // critical section
            {
                if (Balance >= amount)
                {
                    Console.WriteLine($"Withdrawing {amount}...");

                    Thread.Sleep(500); // simulate delay

                    Balance -= amount;

                    Console.WriteLine($"Remaining Balance: {Balance}");
                }
                else
                {
                    Console.WriteLine("Insufficient Balance!");
                }
            }
        }
    }

    static void Main(string[] args)
    {
        BankAccount account = new BankAccount();

        // Multiple threads
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
