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
        //const string FILENAME = "inventory.txt";

        static void Main(string[] args)
        {
        //    StreamReader inventory = new StreamReader(FILENAME);
        //    ArrayList menu = new ArrayList();

        //    Console.WriteLine("                   Welcome to our delivery food service! ");
        //    DisplayInventory(inventory, menu);

        //    Console.Write("What would you like to pick? ");
        //    string input = Console.ReadLine().ToLower().Trim();
        //    //enter in validation for input to match for numbers
        //    //enter in validation for categories

        //    int.TryParse(input, out int choice);




        //    Console.WriteLine();
        //    Console.WriteLine(menu[choice]);
        //    Console.WriteLine();


        //    bool repeat = true;
        //    while (repeat)
        //    {

        //        Console.WriteLine(Validator.GetValidSelection());
        //        Console.WriteLine("Would you like to add this item to your shopping cart? (Y/N): ");
        //        bool addCart = Validator.YesNo();
        //        Console.WriteLine($"You added {0} ${0}to your shopping cart");

        //        Console.WriteLine("Would you like to continue shopping? (Y/N)");
        //        bool shopAgain = Validator.YesNo();

        //        Console.WriteLine("Would you like to checkout? (Y/N)");
        //        bool checkOut = Validator.YesNo();

        //        Console.WriteLine(Validator.Mod10Check());
        //    }

        //}

        //private static void DisplayInventory(StreamReader inventory, ArrayList menu)
        //{
        //    while (true)
        //    {

        //        string line = inventory.ReadLine();
        //        if (string.IsNullOrEmpty(line))
        //        {
        //            break;
        //        }

        //        string[] itemParts = line.Split('\t');
        //        string name = itemParts[0];
        //        string category = itemParts[1];
        //        string description = itemParts[2];
        //        double.TryParse(itemParts[3], out double price);
        //        int.TryParse(itemParts[4], out int quantity);

        //        Product menuItem = new Product(name, category, description, price, quantity);
        //        quantity = menuItem.Quantity;
        //        menu.Add(menuItem);

        //    }
        //    inventory.Close();
        //    Console.WriteLine("             Here is what we have in stock right now! ");
        //    Console.WriteLine("==========================================================================");
        //    for (int i = 0; i < menu.Count; i++)
        //    {
        //        Console.WriteLine($"{i}:{menu[i]}");
        //    }
        //    Console.WriteLine("==========================================================================");


            /****** Scobie ******/
            ShoppingCart cart = new ShoppingCart();
            while (true)
            {
                ArrayList CurrentInventory = cart.LoadInventory();
                ShoppingCart.ListInventory(CurrentInventory);
                

                Console.Write("Do you want to continue? (y/n): ");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int junk))
                {
                    Console.WriteLine();
                    Console.WriteLine("I'm sorry, but that was not a valid option. Please try again");
                    Console.WriteLine();
                    break;
                }
                else if (userInput.ToLower() != "y")
                {
                    break;
                }
               
            }
        }
    }
}