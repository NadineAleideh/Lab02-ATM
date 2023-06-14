namespace Lab02_ATM
{
    public class Program
    {
        public static decimal Balance = 0;
        public static List<string> Transactions = new();

        public static void Main()
        {
            try
            {
                Console.WriteLine("\t\t\t\t*****Welcome to Nadine's Bank our Dear coustmer!*****\n\n");
                UserInterface();
            }

            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("See You Next Time!");
            }
        }

        public static void UserInterface()
        {
            while (true)
            {
                Console.WriteLine("Please choose an option:\n");
                Console.WriteLine("1. View Balance\n");
                Console.WriteLine("2. Withdraw\n");
                Console.WriteLine("3. Deposit\n");
                Console.WriteLine("4. Exit\n");

                string? option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine($"Current Balance: {ViewBalance()}\n");
                        break;
                    case "2":

                        if (Balance == 0)
                        {
                            throw new Exception("Your Balance is 0 you cannot make a withdraw transactions!\n");
                        }
                        Console.WriteLine("Enter money amount to withdraw:");
                        decimal withdrawAmount;
                        if (decimal.TryParse(Console.ReadLine(), out withdrawAmount))
                        {
                            Balance = Withdraw(withdrawAmount);

                        }
                        else
                        {
                            Console.WriteLine("Invalid amount. Please try again.\n");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Enter money amount to deposit:");
                        decimal depositAmount;
                        if (decimal.TryParse(Console.ReadLine(), out depositAmount))
                        {
                            Balance = Deposit(depositAmount);

                        }
                        else
                        {
                            Console.WriteLine("Invalid amount. Please try again.");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Thank you for using the our services! Do you want a receipt? Enter Y or N:\n");
                        while (true)
                        {
                            string option2 = Console.ReadLine().ToLower();


                            switch (option2)
                            {
                                case "y":
                                    GenerateReceipt();
                                    return;

                                case "n":
                                    return;

                                default:
                                    Console.WriteLine("Invalid option. Please try again.");
                                    break;
                            }

                        }

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        public static decimal ViewBalance()
        {
            return Balance;
        }

        public static decimal Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid amount. Please enter a positive value.");
                return Balance;
            }
            else if (amount > Balance)
            {
                Console.WriteLine("you cannot withdraw amount bigger than your Balance!");
                return Balance;
            }
            else
            {
                Balance -= amount;
                RecordTransaction($"Withdraw -> {amount}");
                return Balance;
            }
        }

        public static decimal Deposit(decimal amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Invalid amount. Please enter a positive value.");
                return Balance;
            }
            else
            {
                Balance += amount;
                RecordTransaction($"Deposit -> {amount}");
                return Balance;
            }
        }

        public static void RecordTransaction(string transaction)
        {
            Transactions.Add(transaction);
        }

        public static void GenerateReceipt()
        {
            Console.WriteLine("******** RECEIPT ********");
            Console.WriteLine($"Current Balance: {ViewBalance()}");
            Console.WriteLine("All Transactions:\t");
            foreach (string transaction in Transactions)
            {
                Console.WriteLine(transaction);
            }
            Console.WriteLine("\n************************\n");
        }


    }
}