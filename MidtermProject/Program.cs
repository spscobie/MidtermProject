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
                Console.WriteLine("                                     Here is what we have in stock right now! ");
                Console.WriteLine(new string('+', 105)); //footer
                for (int i = 0; i < menu.Count; i++)
                {
                    Console.WriteLine($"{i}:{menu[i]}");
                }
                Console.WriteLine(new string('+', 105)); //footer

                int selection = Validator.GetValidSelection();//Make sure the number is on the list
                Console.WriteLine();
                Console.WriteLine(menu[selection]);
                Console.WriteLine();
                Product choice = (Product)menu[selection];//Allows to access the variables inside the textfile, which is held in the arraylist.

                int userQuantity = Validator.GetQuantity(selection, menu);// Checks user quantity for in stock


                Console.Write($"Would you like to add {userQuantity} {choice.Name} {choice.Category} boxes to your cart? (Y/N): ");
                bool addCart = Validator.YesNo();//Add to cart validator (Yes or No options)

                if (addCart == true)
                {
                    Console.WriteLine("Added to cart!");
                    ShoppingCart.AddtoCart(cart, (Product)menu[selection], userQuantity);//Adds to the cart and adds the quantity
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
            Console.WriteLine("Thank you for shopping at JorStevIam Holladay Express! Packages will arrive between 10 - 14 business days.");
            Console.WriteLine("*======*======*======*======*======*======*======*======**======*======*======*======*======*======*======*======*");
        }
    }
}