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

            ArrayList productList = GetInventory.CurrentInventory(FILENAME);
            Console.WriteLine("                    Welcome JorStevIam.com Delivery Holladay Service! Selling Holladay Boxes 1 at a time! ");
            Console.WriteLine("                                     JorStevIam, we put the \'Holla\' in \'Holladay\' ");
            Console.WriteLine();

            bool repeat = true;
            while (repeat)
            {
                CategoriesSearch.SearchMethod(productList);

                int selection = Validator.GetValidSelection();//Make sure the number is on the list
                int newSelection = selection - 1;
                Console.WriteLine();
                Console.WriteLine(productList[newSelection]);
                Console.WriteLine();

                Product choice = (Product)productList[newSelection];//Allows to access the variables inside the textfile, which is held in the arraylist.

                int userQuantity = Validator.GetQuantity(newSelection, productList);// Checks user quantity for in stock


                Console.Write($"Would you like to add {userQuantity} {choice.Name} {choice.Category} boxes to your cart? (Y/N): ");
                bool addCart = Validator.YesNo();//Add to cart validator (Yes or No options)
                Console.WriteLine();

                if (addCart == true)
                {
                    Console.WriteLine("Added to cart!");
                    ShoppingCart.AddtoCart(cart, (Product)productList[newSelection], userQuantity);//Adds to the cart and adds the quantity
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Not added to cart! ");
                    Console.WriteLine();
                }


                Console.Write("Would you like to continue shopping? (Y/N): "); //If they would like to keep searching for items or not
                bool shopAgain = Validator.YesNo();
                Console.WriteLine();
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
            Console.WriteLine("Here is your cart!\n");
            Console.WriteLine("ItemName\t\tCategory\tPrice\tQuantity");
            Console.WriteLine("*======*======*======*======*======*======*======*======*");
            ShoppingCart.GetCart(cart);
            Console.WriteLine("*======*======*======*======*======*======*======*======*");
            Console.WriteLine("RECEIPT*********RECEIPT*********RECEIPT*********RECEIPT*********RECEIPT*********RECEIPT");
            ShoppingCart.GetFormattedSalesTax(cart.GetTotal());//Gets the total. Times it by the quantity and the prices inside the cart.
            ShoppingCart.GetFormattedGrandTotal(cart.GetTotal());//Gets the grand total, which is the overall total and times it by the sales tax (.06)
            ShoppingCart.Payment(ShoppingCart.GetGrandTotal(cart.GetTotal()));//Displays what you paid with and the functions within.
            cart.UpdateInventory(productList);
            Console.WriteLine();
            Console.WriteLine("Please enter your shipping information");
            Customer cust = new Customer();
            cust.GetCustomer();

            Console.WriteLine("*======*======*======*======*======*======*======*======**======*======*======*======*======*======*======*======*");
            Console.WriteLine("Thank you for shopping at JorStevIam Holladay Service! Packages will arrive between 10 - 14 business days.");
            Console.WriteLine("*======*======*======*======*======*======*======*======**======*======*======*======*======*======*======*======*");

            Console.WriteLine();
            Console.Write("To add a product, enter \'Y\'. To continue leaving JorStevIam.com, enter \'N\' : ");
            string answer = Console.ReadLine().ToLower().Trim();

            if (answer == "y")
            {
                productList = AdminPassword(productList);
            }
            else
            {
                Console.WriteLine("You are not an admin. Leaving store.... ");
                return;
            }

            cart.UpdateInventory(productList);
        }

        private static ArrayList AdminPassword(ArrayList productList) // Method for adding and item to an inventory.
        {
            bool correct = true;
            while (correct)
            {
                Console.WriteLine("Please enter in Admin Password: ");
                string password = Console.ReadLine();

                int attempts = 5;
                while (attempts > 0)
                {
                    if (password != "SantaClaus")
                    {
                        Console.WriteLine("Wrong password! Please try again ({0} attempt(s) left)", 0 + attempts);
                        Console.Write("Please enter in Admin Password: ");
                        password = Console.ReadLine();
                        Console.WriteLine();
                        attempts--;
                    }
                    else
                    {
                        break;
                    }
                }

                if (attempts <= 0 && (password != "SantaClause"))
                {
                    Console.WriteLine("Wrong password you filthy animal. Tried too many times. ");
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter the item you wish to add in this order: Item, category, description, price, quantity.");
                    GetInventory.AddInventory(FILENAME, productList);
                    productList = GetInventory.CurrentInventory(FILENAME);
                }
            }

            return productList;
        }
    }
}