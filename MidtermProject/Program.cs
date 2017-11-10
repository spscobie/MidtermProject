using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject
{
    class Program
    {
        const string FILENAME = "inventory.txt";

        static void Main(string[] args)
        {
            ShoppingCart cart = new ShoppingCart();
            ArrayList menu = GetInventory.CurrentInventory(FILENAME);
            Console.WriteLine("                                 Welcome to JorStevIam Delivery Holladay Service! ");
            Console.WriteLine("                                      Where we put the \'Holla\' in \'Holladay\' ");
            Console.WriteLine();

            bool repeat = true;
            while (repeat)
            {
                SearchMethod(menu);//Asks the user to search by category

                int selection = Validator.GetValidSelection();//Make sure the number is on the list
                int newSelection = selection - 1;
                Console.WriteLine();
                Console.WriteLine(menu[newSelection]);
                Console.WriteLine();
                Product choice = (Product)menu[newSelection];//Allows to access the variables inside the textfile, which is held in the arraylist.

                int userQuantity = Validator.GetQuantity(newSelection, menu);// Checks user quantity for in stock


                Console.Write($"Would you like to add {userQuantity} {choice.Name} {choice.Category} boxes to your cart? (Y/N): ");
                bool addCart = Validator.YesNo();//Add to cart validator (Yes or No options)

                if (addCart == true)
                {
                    Console.WriteLine("Added to cart!");
                    ShoppingCart.AddtoCart(cart, (Product)menu[newSelection], userQuantity);//Adds to the cart and adds the quantity
                }
                else
                {
                    Console.WriteLine("Not added to cart! ");
                }


                Console.Write("Would you like to continue shopping? (Y/N): ");
                bool shopAgain = Validator.YesNo();

                if (shopAgain == true)
                {
                    repeat = true;
                }
                else
                {
                    repeat = false;
                }
            }

            Console.WriteLine("Proceeding to checkout.... ");
            Console.WriteLine("Here is your cart!");
            Console.WriteLine("ItemName\t\tCategory\tPrice\tQuantity");
            Console.WriteLine("*======*======*======*======*======*======*======*======*");
            ShoppingCart.GetCart(cart);
            Console.WriteLine("*======*======*======*======*======*======*======*======*");
            ShoppingCart.GetFormattedSalesTax(cart.GetTotal());//Gets the total. Times it by the quantity and the prices inside the cart.
            ShoppingCart.GetFormattedGrandTotal(cart.GetTotal());//Gets the grand total, which is the overall total and times it by the sales tax (.06)
            ShoppingCart.Payment(ShoppingCart.GetGrandTotal(cart.GetTotal()));//
            Console.WriteLine();
            Console.WriteLine("*======*======*======*======*======*======*======*======**======*======*======*======*======*======*======*======*");
            Console.WriteLine("Thank you for shopping at JorStevIam Holladay Service! Packages will arrive between 10 - 14 business days.");
            Console.WriteLine("*======*======*======*======*======*======*======*======**======*======*======*======*======*======*======*======*");
        }

        private static void SearchMethod(ArrayList menu)
        {
            Console.WriteLine("Here are our current ways to search!\n1.)Christmas\n2.)Valentines\n3.)Thanksgiving\n4.)FourthOfJuly\n5.)Everything ");
            Console.Write("Please enter the number for what option you would like: ");
            string option = Console.ReadLine().ToLower().Trim();
            Console.WriteLine();

            if (option == "1" || option == "christmas")
            {
                Console.WriteLine("                                 You chose to search by Christmas! ");
                Console.WriteLine(new string('+', 105)); //footer
                for (int i = 0; i <= 3; i++)
                {
                    Console.WriteLine($"{i + 1}:{menu[i]}");
                }
                Console.WriteLine(new string('+', 105)); //footer
            }
            if (option == "2" || option == "valentines")
            {
                Console.WriteLine("                                 You chose to search by Valentines! ");
                Console.WriteLine(new string('+', 105)); //footer
                for (int i = 4; i <= 7; i++)
                {
                    Console.WriteLine($"{i + 1}:{menu[i]}");
                }
                Console.WriteLine(new string('+', 105)); //footer
            }
            if (option == "3" || option == "thanksgiving")
            {
                Console.WriteLine("                                 You chose to search by Thanksgiving! ");
                Console.WriteLine(new string('+', 105)); //footer
                for (int i = 8; i <= 11; i++)
                {
                    Console.WriteLine($"{i + 1}:{menu[i]}");
                }
                Console.WriteLine(new string('+', 105)); //footer
            }
            if (option == "4" || option == "fourthofjuly")
            {
                Console.WriteLine("                                 You chose to search by FourthOfJuly! ");
                Console.WriteLine(new string('+', 105)); //footer
                for (int i = 12; i < 16; i++)
                {
                    Console.WriteLine($"{i + 1}:{menu[i]}");
                }
                Console.WriteLine(new string('+', 105)); //footer
            }
            else if (option == "5" || option == "everything")
            {
                Console.WriteLine("                                 You chose to search by everything! ");
                Console.WriteLine(new string('+', 105)); //footer
                for (int i = 0; i < menu.Count; i++)
                {
                    Console.WriteLine($"{i + 1}:{menu[i]}");
                }
                Console.WriteLine(new string('+', 105)); //footer
            }
        }
    }
}