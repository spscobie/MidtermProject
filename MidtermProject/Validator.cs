using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject
{
    class Validator
    {

        public static int GetValidSelection()
        {

            Console.Write("Please pick what number you would like to order: ");
            bool success = int.TryParse(Console.ReadLine(), out int selection);




            if (!success)
            {
                Console.WriteLine("Please enter a valid number from the list!");
                return GetValidSelection();

            }

            else if (selection > 16 || selection < 1)
            {
                Console.Write("That is not one of our products! ");
                return GetValidSelection();
            }

            return selection;
        }

        public static int GetQuantity(int selection, ArrayList menu)
        {
            int userQuantity = 0;
            while (true)
            {
                Product choice = (Product)menu[selection];
                Console.Write($"Please pick how many you would like of the {choice.Name} {choice.Category} package: ");

                bool validQty = int.TryParse(Console.ReadLine(), out userQuantity);
                if (!validQty || userQuantity < 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("That was not a valid entry. Please try again.");
                    Console.WriteLine();
                }
                else if (choice.Quantity == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("I'm sorry, but we are all out of that product at the moment.");
                    Console.WriteLine();
                }
                else if (userQuantity > choice.Quantity)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Sorry, not enough in stock! We only have {choice.Quantity} left.");
                    Console.WriteLine();
                }
                else
                {
                    choice.Quantity = choice.Quantity - userQuantity;
                    return userQuantity;
                }
            }

            
        }



        public static bool YesNo()
        {
            bool valid = true;
            bool repeat = true;

            while (valid)
            {
                string answer = Console.ReadLine().ToLower();
                if (answer == "y" || answer == "yes")
                {
                    valid = false;
                    repeat = true;
                }
                else if (answer == "n" || answer == "no")

                {
                    valid = false;
                    repeat = false;
                }
                else
                {
                    Console.Write("Did not enter a valid input. Please enter (Y/N): ");
                }
            }
            return repeat;
        }

        public static bool Mod10Check()
        {


            Console.WriteLine("Enter your credit card information:\n");

            Console.Write("Enter you credit card number: ");

            string ccNum = Console.ReadLine().Trim();

            int sumOfDigits = ccNum.Where((e) => e >= '0' && e <= '9')
                               .Reverse()
                               .Select((e, i) => ((int)e - 48) * (i % 2 == 0 ? 1 : 2))
                               .Sum((e) => e / 10 + e % 10);
            if (sumOfDigits % 10 != 0 || ccNum.Length != 16)
            {
                Console.WriteLine("That credit card is not valid. Please enter another credit card number: ");
                return false;
            }


            while (true)
            {
                Console.Write("Enter the 2 digit expiration MONTH of your credit card:  \n");
                string expMonth = Console.ReadLine().Trim();
                int validMonth = 0;
                bool success = false;
                success = !int.TryParse(expMonth, out validMonth);

                if (string.IsNullOrEmpty(expMonth))
                {
                    Console.WriteLine("You did not enter a valid month. Please try again: \n");
                }

                else if (expMonth.Length != 2)
                {
                    Console.WriteLine("The expiration month is not valid. It should have 2 digits: ");
                }
                else if (validMonth < 01 || validMonth > 12)
                {
                    Console.WriteLine("That is not a valid month. Try again: ");
                }
                else
                {
                    break;
                }
            }

            while (true)
            {
                Console.Write("Now enter the 2 digit expiration YEAR of your credit card:  \n");
                string expYear = Console.ReadLine().Trim();
                int validYear = 0;
                bool success2 = false;
                success2 = !int.TryParse(expYear, out validYear);
                if (string.IsNullOrEmpty(expYear))
                {
                    Console.WriteLine("The expiration year is not valid. Please try again: \n");
                }

                else if (expYear.Length != 2)
                {
                    Console.WriteLine("The expiration year is not valid. It should have 2 digits: ");
                }
                else if (validYear < 17)
                {
                    Console.WriteLine("That is not a valid year. Try again: ");
                }
                else
                {
                    break;
                }
            }




            int validCvv = 0;
            bool success3 = false;
            while (true)
            {
                Console.Write("Enter the 3 digit CVV code on the back of the card:");
                string cvv = Console.ReadLine().Trim();

                success3 = int.TryParse(cvv, out validCvv);
                if (string.IsNullOrEmpty(cvv))
                {
                    Console.WriteLine("The code you entered is not valid. Please try again: \n");
                }

                else if (cvv.Length != 3)
                {
                    Console.WriteLine("The code is not valid. It should have 3 digits: ");
                }

                else
                {
                    const int ExclusiveUpperBound = 2;
                    if (new Random().Next(ExclusiveUpperBound) == 0)
                    {
                        Console.WriteLine("You transaction was a success! Thank you for shopping with us");
                    }
                    else
                    {
                        Console.WriteLine("Transaction declined. Have a nice day.");
                        return false;
                    }
                    break;
                }

            }
            return true;


        }

        public static bool GetValidBankAccount()
        {
            bool success = false;
            int validBa = 0;
            while (!success)
            {
                Console.Write("Enter your bank account number: ");
                string bankInfo = Console.ReadLine().Trim();
                bool success2 = int.TryParse(bankInfo, out validBa);

                if (!success2)
                {
                    Console.WriteLine("The bank account you entered was not valid. Please try again: ");
                    success = false;

                }
                else if (validBa <= 10000000 || validBa >= 999999999)
                {
                    Console.WriteLine("That is not a valid bank account.\n Your bank account has 8 or 9 digits. \n Try again");
                    success2 = false;
                }
                else
                {
                    Console.WriteLine("Your bank account is accepted.");
                    success = true;
                }


            }
            return true;
        }

        public static bool GetValidCash(double grandTotal)
        {
            bool repeat = true;
            while (repeat)
            {
                Console.WriteLine();
                Console.Write($"Please jam {grandTotal:C} through the computer: ");
                string input = Console.ReadLine();
                bool success = double.TryParse(input, out double payment);
                double change = payment - grandTotal;

                if (!success)
                {
                    Console.WriteLine("Are you really going to get complicated about this stuff? Just enter in the amount you want to pay with");
                    repeat = true;
                }
                else if (payment < grandTotal)
                {
                    Console.WriteLine("You still owe us money.. Pay the full amount or over! ");
                    repeat = true;
                }
                else
                {
                    Console.Write($"We won't give you a reciept beacuse this is an online store, but here is your change: {change:C}\n");
                    repeat = false;
                }
            }

            return true;
        }
    }
}