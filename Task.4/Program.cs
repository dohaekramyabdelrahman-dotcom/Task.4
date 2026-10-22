namespace Task._4
{
    using System;
    using System.Runtime.InteropServices.Marshalling;
    using System.Security.Cryptography.X509Certificates;
    using System.Security.Principal;
    using System.Xml.Linq;

    public class Account
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public Account(string name = "Unnamed Account", double balance = 0.0)
        {
            this.Name = name;
            this.Balance = balance;
        }

        public virtual bool Deposit(double amount)
        {
            if (amount < 0)
                return false;
            else
            {
                Balance += amount;
                return true;
            }
        }

        public virtual bool Withdraw(double amount)
        {
            if (Balance - amount >= 0)
            {
                Balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }
        public virtual string GetAccountType()
        {
            return "Account";
        }

    }
    public class SavingsAccount : Account
    {
        public override bool Deposit(double amount)
        {
            return base.Deposit(amount);
        }
        public override string GetAccountType()
        {
            return "Saving Account";
        }

        public SavingsAccount(string name, double balance, double interestrate) : base(name, balance)
        {
            Interestrate = interestrate;
        }

        public double Interestrate { get; set; }

    }
    public class CheckingAccount : Account
    {
        public override bool Withdraw(double amount)
        {
            if (amount + Fee > Balance)
            {
                return false;
            }
            return base.Withdraw(amount + Fee);

        }
        public override string GetAccountType()
        {
            return "Checking Account";
        }

        public CheckingAccount(string name, double balance) : base(name, balance)
        {


        }
        public double Fee = 1.50;
    }
    public class TrustAccount : Account
    {
        public override bool Deposit(double amount)
        {
            bool sus = base.Deposit(amount);
            if (sus && amount >= 5000)
            {
                Balance += 50.0;
            }

            return sus;


        }
        int withdrawalcount = 0;
        int withdrawalyear = 0;
        public override bool Withdraw(double amount)
        {
            if (withdrawalyear != DateTime.Now.Year)
            {
                withdrawalcount = 0;
                withdrawalyear = DateTime.Now.Year;
            }
            if (withdrawalcount >= 3 || amount >= Balance * 0.20)
            {
                return false;
            }
            bool sus = base.Withdraw(amount);
            if (sus)
            {
                withdrawalcount++;
            }
            return sus;

        }
        public override string GetAccountType()
        {
            return "Trust Account";
        }
        public TrustAccount(string name, double balance, double interestrate) : base(name, balance)
        {
            Interestrate = interestrate;
        }
        public double Interestrate { get; set; }

    }









    internal class Program
    {

        static void Main(string[] args)
        {
            // Accounts
            var accounts = new List<Account>();
            accounts.Add(new Account());
            accounts.Add(new Account());
            accounts.Add(new Account());
            accounts.Add(new Account());

            AccountUtil.Deposit(accounts, 1000);
            AccountUtil.Withdraw(accounts, 2000);

            // Savings
            var savAccounts = new List<SavingsAccount>();
            savAccounts.Add(new SavingsAccount("Robin", 3000, 5.0));
            savAccounts.Add(new SavingsAccount("Superman", 5000, 5.0));
            savAccounts.Add(new SavingsAccount("Batman", 2000, 5.0));
            savAccounts.Add(new SavingsAccount("Wonderwoman", 5000, 5.0));

            AccountUtil.Deposit(savAccounts, 1000);
            AccountUtil.Withdraw(savAccounts, 2000);

            // Checking
            var checAccounts = new List<CheckingAccount>();
            checAccounts.Add(new CheckingAccount("adam2", 4000));
            checAccounts.Add(new CheckingAccount("Larry2", 5000));
            checAccounts.Add(new CheckingAccount("Moe2", 2000));
            checAccounts.Add(new CheckingAccount("Curly2", 5000));

            AccountUtil.Deposit(checAccounts, 1000);
            AccountUtil.Withdraw(checAccounts, 2000);
            AccountUtil.Withdraw(checAccounts, 2000);

            // Trust
            var trustAccounts = new List<TrustAccount>();
            trustAccounts.Add(new TrustAccount("Robin2", 7000, 5.0));
            trustAccounts.Add(new TrustAccount("Superman2", 4000, 5.0));
            trustAccounts.Add(new TrustAccount("Batman2", 2000, 5.0));
            trustAccounts.Add(new TrustAccount("Wonderwoman2", 5000, 5.0));

            AccountUtil.Deposit(trustAccounts, 1000);
            AccountUtil.Deposit(trustAccounts, 6000);
            AccountUtil.Withdraw(trustAccounts, 2000);
            AccountUtil.Withdraw(trustAccounts, 3000);
            AccountUtil.Withdraw(trustAccounts, 500);

            Console.WriteLine();





            //SHERCH(EXCEPTION PROGRAM)
            #region interger number
            List<int> Number = new List<int>();
            Console.WriteLine("enter number");
            int count = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("enter number");
                int num = Convert.ToInt32(Console.ReadLine());
                foreach (int n in Number)
                {
                    if (num == n)
                    {
                        throw new Exception("duplicate number found");
                    }
                }
                Number.Add(num);
            }
            Console.WriteLine("all number are unique");
            #endregion
            #region vowels
            Console.WriteLine("enter text");
            string text = Console.ReadLine();
            vowels(text);
            #endregion










        }
        //public static class AccountUtil
        //{
        //    // Utility helper functions for Account class
        //    public static void Deposit(List<Account> accounts, double amount)
        //    {
        //        Console.WriteLine("\n=== Depositing to Accounts =================================");
        //        foreach (var acc in accounts)
        //        {
        //            if (acc.Deposit(amount))
        //                Console.WriteLine($"Deposited {amount} to {acc}");
        //            else
        //                Console.WriteLine($"Failed Deposit of {amount} to {acc}");
        //        }
        //    }

        //    public static void Withdraw(List<Account> accounts, double amount)
        //    {
        //        Console.WriteLine("\n=== Withdrawing from Accounts ==============================");
        //        foreach (var acc in accounts)
        //        {
        //            if (acc.Withdraw(amount))
        //                Console.WriteLine($"Withdrew {amount} from {acc}");
        //            else
        //                Console.WriteLine($"Failed Withdrawal of {amount} from {acc}");
        //        }
        //    }

        //    // Helper functions for SavingsAccount
        //    public static void DepositSavings(List<SavingsAccount> accounts, double amount)
        //    {
        //        Console.WriteLine("\n=== Depositing to Savings Accounts =================================");
        //        foreach (var acc in accounts)
        //        {
        //            if (acc.Deposit(amount))
        //                Console.WriteLine($"Deposited {amount} to {acc}");
        //            else
        //                Console.WriteLine($"Failed Deposit of {amount} to {acc}");
        //        }
        //    }

        //    public static void WithdrawSavings(List<SavingsAccount> accounts, double amount)
        //    {
        //        Console.WriteLine("\n=== Withdrawing from Savings Accounts ==============================");
        //        foreach (var acc in accounts)
        //        {
        //            if (acc.Withdraw(amount))
        //                Console.WriteLine($"Withdrew {amount} from {acc}");
        //            else
        //                Console.WriteLine($"Failed Withdrawal of {amount} from {acc}");
        //        }
        //    }

        //    // Helper functions for CheckingAccount
        //    public static void DepositChecking(List<CheckingAccount> accounts, double amount)
        //    {
        //        Console.WriteLine("\n=== Depositing to Checking Accounts =================================");
        //        foreach (var acc in accounts)
        //        {
        //            if (acc.Deposit(amount))
        //                Console.WriteLine($"Deposited {amount} to {acc}");
        //            else
        //                Console.WriteLine($"Failed Deposit of {amount} to {acc}");
        //        }
        //    }

        //    public static void WithdrawChecking(List<CheckingAccount> accounts, double amount)
        //    {
        //        Console.WriteLine("\n=== Withdrawing from Checking Accounts ==============================");
        //        foreach (var acc in accounts)
        //        {
        //            if (acc.Withdraw(amount))
        //                Console.WriteLine($"Withdrew {amount} from {acc}");
        //            else
        //                Console.WriteLine($"Failed Withdrawal of {amount} from {acc}");
        //        }
        //    }

        //    // Helper functions for TrustAccount
        //    public static void DepositTrust(List<TrustAccount> accounts, double amount)
        //    {
        //        Console.WriteLine("\n=== Depositing to Trust Accounts =================================");
        //        foreach (var acc in accounts)
        //        {
        //            if (acc.Deposit(amount))
        //                Console.WriteLine($"Deposited {amount} to {acc}");
        //            else
        //                Console.WriteLine($"Failed Deposit of {amount} to {acc}");
        //        }
        //    }

        //    public static void WithdrawTrust(List<TrustAccount> accounts, double amount)
        //    {
        //        Console.WriteLine("\n=== Withdrawing from Trust Accounts ==============================");
        //        foreach (var acc in accounts)
        //        {
        //            if (acc.Withdraw(amount))
        //                Console.WriteLine($"Withdrew {amount} from {acc}");
        //            else
        //                Console.WriteLine($"Failed Withdrawal of {amount} from {acc}");
        //        }
        //    }
        //}
        public class AccountUtil
        {

            public static void Deposit<T>(List<T> accounts, double amount)
              where T : Account
            {
                foreach (T acc in accounts)
                {
                    if (acc.Deposit(amount))
                        Console.WriteLine($"Deposited {amount} to {acc.GetAccountType()}");
                    else
                        Console.WriteLine($"Failed Deposit of {amount} to {acc.GetAccountType()}");
                }
            }
            public static void Withdraw<T>(List<T> accounts, double amount)
                where T : Account
            {
                foreach (T acc in accounts)
                {
                    if (acc.Withdraw(amount))
                        Console.WriteLine($"Withdraw {amount} from {acc.GetAccountType()}");
                    else
                        Console.WriteLine($"Failed Withdraw of {amount} from {acc.GetAccountType()}");
                }
            }



        }
        #region method vowel
        static void vowels(string text)
        {
            bool check = false;
            foreach (char a in text)
            {
                if (a == 'a' || a == 'e' || a == 'i' || a == 'o' || a == 'u' || a == 'A' || a == 'E' || a == 'I' || a == 'O' || a == 'U')
                {
                    check = true;
                }
            }
            if (check == false)
            {
                throw new Exception("the string does not contain vowel");
            }
            Console.WriteLine("the string contains vowel");
        }
        #endregion

    }
        }







