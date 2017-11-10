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
            ArrayList menu = new ArrayList();
            //ArrayList cart = new ArrayList();
            StreamReader inventory = new StreamReader(FILENAME);

            Console.WriteLine("                   Welcome to our delivery food service! ");
            menu = ShoppingCart.LoadInventory();
            ShoppingCart.ListInventory(menu);
            //DisplayInventory(inventory, menu);

            bool repeat = true;
            while (repeat)
            {
                Console.WriteLine("                  Here is what we have in stock right now! ");
                Console.WriteLine("==========================================================================");
                for (int i = 0; i < menu.Count; i++)
                {
                    Console.WriteLine($"{i}:{menu[i]}");
                }
                Console.WriteLine("==========================================================================");

                int selection = Validator.GetValidSelection();//Make sure the number is on the list
                Console.WriteLine();
                Console.WriteLine(menu[selection]);
                Console.WriteLine();
                //Product choice = (Product)menu[selection];


                cart.AddToCart(selection, menu);



                Console.Write("Would you like to add this item to your shopping cart? (Y/N): ");
                bool addCart = Validator.YesNo();

                if (addCart == true)
                {
                    Console.WriteLine("Added to cart!");
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

            Console.Write($"You're total is ${0.00}.\n");

            Console.WriteLine("Here are our current payment methods:\n1.)Cash\n2.)Check\n3.)Credit");
            Console.Write("Please enter how you would like to pay: ");

            string payment = Console.ReadLine().ToLower();

            if (payment == "1" || payment == "cash")
            {
                Console.Write($"You're total is {0}. \nPlease enter how much you are paying with: ");
                double.TryParse(Console.ReadLine(), out double change);
                Console.WriteLine($"Your change is {0}");
            }
            else if (payment == "2" || payment == "check")
            {
                Console.Write("Please enter in your check number: ");
                int.TryParse(Console.ReadLine(), out int check);
            }
            else if (payment == "3" || payment == "credit")
            {
                Console.WriteLine(Validator.Mod10Check());
            }


            //Console.WriteLine("Would you like to checkout? (Y/N)");
            //bool checkOut = Validator.YesNo();

            // Console.WriteLine(Validator.Mod10Check());

        }

        private static void DisplayInventory(StreamReader inventory, ArrayList menu)
        {
            while (true)
            {

                string line = inventory.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    break;
                }

                string[] itemParts = line.Split('\t');
                string name = itemParts[0];
                string category = itemParts[1];
                string description = itemParts[2];
                double.TryParse(itemParts[3], out double price);
                int.TryParse(itemParts[4], out int quantity);

                Product menuItem = new Product(name, category, description, price, quantity);
                quantity = menuItem.Quantity;
                menu.Add(menuItem);

            }
            inventory.Close();
        }
    }
}