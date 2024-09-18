using System.Collections.Generic;
using System;


namespace Bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            DisplayLogo();
            RunBankApplication();
        }

        static void DisplayLogo()
        {
            // Metod för att visa logotypen
            Console.WriteLine("EH Financials");
        }
        // Metod som innehåller bankomatslogiken
        static void RunBankApplication()
        {
            
            int maxDepositAmount = 10000;
            int maxWithdrawalAmount = 5000;

            List<string> pinCodes = new List<string> { "4450", "1337", "1178" };
            List<int> balance = new List<int> { 3000, 700, 10000 };
            int index;
            bool loggedIn = false;

            do
            {
                Console.Write("Ange PIN: ");
                string pinInput = Console.ReadLine();
                index = pinCodes.IndexOf(pinInput);

                if (index < 0)
                {
                    Console.WriteLine("Fel PIN, försök igen.");
                }
            } while (index < 0);

            Console.WriteLine("PIN korrekt. Välkommen, kund nr: " + index);

            while (!loggedIn)
            {
                bool menuTime = true;
                while (menuTime)
                {
                    Console.WriteLine("Meny: ");
                    Console.WriteLine("1. Se saldo");
                    Console.WriteLine("2. Sätt in pengar");
                    Console.WriteLine("3. Ta ut pengar");
                    Console.WriteLine("4. Avsluta");
                    Console.Write("Välj ett alternativ: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine("Ditt saldo är: " + balance[index] + " kr");
                            break;
                        case "2":
                            HandleDeposit(maxDepositAmount, balance, index);
                            break;
                        case "3":
                            
                            break;
                        case "4":
                            Console.WriteLine("Tack för att du använder EH Financials. Hej då!");
                            menuTime = false;
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Felaktigt svar. Försök igen");
                            break;
                    }
                }
            }
        }

        static void HandleDeposit(int maxDepositAmount, List<int> balance, int index)
        {
            Console.WriteLine("Hur mycket vill du sätta in?");
            if (int.TryParse(Console.ReadLine(), out int depositAmount))
            {
                if (depositAmount <= maxDepositAmount)
                {
                    balance[index] += depositAmount;
                    Console.WriteLine("Du har satt in " + depositAmount + " kr. Nytt saldo: " + balance[index] + " kr");
                }
                else
                {
                    Console.WriteLine("Maximal insättning är " + maxDepositAmount + " kr.");
                }
            }
            else
            {
                Console.WriteLine("Ogiltigt belopp.");
            }
        }
    }
}