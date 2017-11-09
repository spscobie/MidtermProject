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
            ArrayList menu = ShoppingCart.CurrentInventory(FILENAME);
            Console.WriteLine("                   Welcome to our delivery food service! ");

            bool repeat = true;
            while (repeat)
            {
                Console.WriteLine("                  Here is what we have in stock right now! ");
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
                    ShoppingCart.AddtoCart(cart, (Product)menu[selection],userQuantity);//Adds to the cart and adds the quantity
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
            Console.WriteLine();
            ShoppingCart.GetCart(cart);

            Console.WriteLine();
            //ShoppingCart.GetTotal();
            Console.WriteLine();

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
    }
}