using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject
{
    class CategoriesSearch
    {
        public static int SearchMethod(ArrayList menu) //Searches for what categories you would like to try and find.
        {
            Console.WriteLine("Here are our current ways to search!\n1.)Christmas\n2.)Valentines\n3.)Thanksgiving\n4.)Fourth Of July\n5.)Everything ");
            Console.Write("Please enter the number for what option you would like: ");
            string option = Console.ReadLine().ToLower().Trim();
            Console.WriteLine();

            int newselection = 0;

            if (option == "1" || option == "christmas")
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("                                 You chose to search by Christmas! ");
                Console.WriteLine("ItemName\t\tCategory\t  Description\t\t\t   Price\t  Quantity");
                Console.WriteLine(new string('+', 105));
                for (int i = 0; i <= 3; i++)
                {
                    Console.WriteLine($"{i + 1}:{menu[i]}");
                }
                Console.WriteLine(new string('+', 105)); //footer

            }
            else if (option == "2" || option == "valentines")
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                                 You chose to search by Valentines! ");
                Console.WriteLine("ItemName\t\tCategory\t  Description\t\t\t   Price\t  Quantity");
                Console.WriteLine(new string('+', 105));
                for (int i = 4; i <= 7; i++)
                {
                    Console.WriteLine($"{i + 1}:{menu[i]}");
                }
                Console.WriteLine(new string('+', 105)); //footer

            }
            else if (option == "3" || option == "thanksgiving")
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("                                 You chose to search by Thanksgiving! ");
                Console.WriteLine("ItemName\t\tCategory\t  Description\t\t\t   Price\t  Quantity");
                Console.WriteLine(new string('+', 105)); //footer
                for (int i = 8; i <= 11; i++)
                {
                    Console.WriteLine($"{i + 1,-3}:{menu[i]}");
                }
                Console.WriteLine(new string('+', 105)); //footer

            }
            else if (option == "4" || option == "fourthofjuly")
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                                 You chose to search by Fourth Of July! ");
                Console.WriteLine("ItemName\t\tCategory\t  Description\t\t\t   Price\t  Quantity");
                Console.WriteLine(new string('+', 105)); //footer
                for (int i = 12; i < 16; i++)
                {
                    Console.WriteLine($"{i + 1,-3}:{menu[i]}");
                }
                Console.WriteLine(new string('+', 105)); //footer
            }
            else if (option == "5" || option == "everything")
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                                 You chose to search by everything! ");
                Console.WriteLine("ItemName\t\tCategory\t  Description\t\t\t   Price\t  Quantity");
                Console.WriteLine(new string('+', 105)); //footer
                for (int i = 0; i < menu.Count; i++)
                {
                    Console.WriteLine($"{i + 1,-3}:{menu[i]}");
                }
                Console.WriteLine(new string('+', 105)); //footer
            }
            else
            {
                Console.WriteLine("Please pick from the options listed above! ");
                SearchMethod(menu);
            }

            return newselection;
        }
    }
}