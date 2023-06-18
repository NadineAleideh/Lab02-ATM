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
                Console.WriteLine("Please choose an transaction:\n");
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
                        
                            Balance = Withdraw(GetAmount());

                        break;
                    case "3":
                        Console.WriteLine("Enter money amount to deposit:");
                        Balance = Deposit(GetAmount());
                        
                        break;
                    case "4":
                        Console.WriteLine("Thank you for using the our services! Do you want a receipt? Enter Y or N:\n");
                       GenerateReceipt();
                       return;


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
      
            if (amount > Balance)
            {
                Console.WriteLine($"since your Balance {Balance} you cannot withdraw amount bigger than your Balance!");
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
                Balance += amount;
                RecordTransaction($"Deposit -> {amount}");
                return Balance;
        }

        public static void RecordTransaction(string transaction)
        {
            Transactions.Add(transaction);
        }

        public static void GenerateReceipt()
        {
            string? userinput;
            userinput = Console.ReadLine()!;
            string testedValue = userinput.ToLower();
            bool validate = ValidateInputRecipet(testedValue);

            while (!validate)
            {
                Console.WriteLine("please enter y if yes or n if no");
                userinput = Console.ReadLine()!;
                testedValue = userinput.ToLower();
                validate = ValidateInputRecipet(testedValue);
            }

            if (testedValue == "y")
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
            else
            {
                return;
            }
        }

        public static decimal GetAmount()
        {
            string ? userinput;
            userinput  = Console.ReadLine()!;
            bool validate = ValidateInput(userinput);

            while (!validate)
            {
                Console.WriteLine("please enter a valid amount");
                userinput = Console.ReadLine()!;
                validate  = ValidateInput(userinput);
            }
            decimal input = Convert.ToDecimal(userinput);

            return input;
        }

        public static bool ValidateInput(string input)
        {
            try
            {
                decimal testValue = Convert.ToDecimal(input);
                if (testValue <= 0)
                    return false;
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static bool ValidateInputRecipet(string input)
        { 
                if (input == "y" || input == "n")
                {
                    return true;
                }
            else
            {
                return false;

            }
                
           
        }
    }
}