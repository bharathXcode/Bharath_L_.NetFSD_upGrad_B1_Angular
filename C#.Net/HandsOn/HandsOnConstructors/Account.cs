using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace HandsOnConstructors
{
    internal class Account
    {
        public double balance = 342903;
        //Private Constructor
        //It used to restrict objet creation using new 
        private Account()
        {

        }
        public static Account GetObject()
        {
            Account account = new Account();
            return account;
        }
      
    }
    class Test_Account
    {
        static void Main()
        {
            Account account = Account.GetObject();
            Console.WriteLine("Balance: " + account.balance);
        }
    }
}
