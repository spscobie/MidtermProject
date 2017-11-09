using System;
using System.Collections;
using System.Collections.Generic;
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

            else if (selection > 12 || selection < 1)
            {
                Console.Write("That is not one of our products! ");
                return GetValidSelection();
            }

            return selection;
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

            Console.Write("Enter you credit card number: ");
            string ccNum = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(ccNum))
            {
                Console.WriteLine("The credit card you entered was not valid. Please try again: ");
                return false;

            }

            int sumOfDigits = ccNum.Where((e) => e >= '0' && e <= '9')
                            .Reverse()
                            .Select((e, i) => ((int)e - 48) * (i % 2 == 0 ? 1 : 2))
                            .Sum((e) => e / 10 + e % 10);

            return sumOfDigits % 10 == 0;
        }

        public static int GetQuantity(int selection, ArrayList menu)
        {
            int userQuantity = 0;
            bool quantityCheck = true;
            while (quantityCheck)
            {
                Product choice = (Product)menu[selection];
                Console.Write($"Please pick how many you would like of the {choice.Name} {choice.Category} package: ");
                int.TryParse(Console.ReadLine(), out userQuantity);

                int stock = choice.Quantity;

                if (userQuantity <= stock)
                {
                    choice.Quantity = stock - userQuantity;
                    break;
                    //return choice.Quantity;
                }

                else
                {
                    Console.WriteLine($"Sorry, not enough in stock! We only have {choice.Quantity} left.");
                }


            }

            return userQuantity;
        }
    }
}
