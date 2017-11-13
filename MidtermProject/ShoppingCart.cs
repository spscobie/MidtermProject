﻿using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject
{
    class ShoppingCart
    {
        private const string INVENTORY = "Inventory.txt";

        private StreamReader fileIn;
        private StreamWriter fileOut;
        private static double total;

        private ArrayList userCart;

        public ArrayList UserCart
        {
            get { return userCart; }
            set { userCart = value; }
        }

        private ArrayList quantity;

        public ArrayList Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public double Total
        {
            get { return total; }
            set { total = value; }
        }

        public ShoppingCart()
        {
            ArrayList cart = new ArrayList();
            ArrayList quantities = new ArrayList();
            userCart = cart;
            Quantity = quantities;
        }

        public static void AddtoCart(ShoppingCart cart, Product selection, int quantity)
        {
            cart.userCart.Add(selection);
            cart.quantity.Add(quantity);
        }

        public static void GetCart(ShoppingCart cart)
        {
            int qty = 0;
            foreach (Product item in cart.UserCart)
            {
                Console.WriteLine($"{item.Name}\t\t{item.Category}\t{item.Price:C}\t{cart.Quantity[qty]}");
                qty++;
            }
        }

        public double GetTotal() //Gets the total for the shopping cart. Multiplies the quantity by the item, for everyitem. 
        {
            double total = 0;
            int selection = 0;
            foreach (Product i in userCart)
            {
                double price = i.Price;
                int qty = (int)quantity[selection];
                selection++;
                total += (price * qty);
            }
            Total = total;
            return total;
        }

        private string FormatTotal(double x)//Formats the total into a current currency
        {
            return $"{x:C}";
        }

        public string GetFormattedTotal()
        {
            return FormatTotal(GetTotal());
        }

        public double GetSalesTax(double total)
        {
            double salestax = total * .06;
            return salestax;
        }

        public static string GetFormattedSalesTax(double salestax)//Formats the salestax into a current currency
        {
            return $"{salestax:C}";
        }
        public static double GetGrandTotal(double total)
        {
            double grandtotal = (total) * .06 + total;
            return grandtotal;
        }
        public static string GetFormattedGrandTotal(double grandtotal)//Formats the grandTotal into a current currency
        {
            return $"{grandtotal:C}";
        }

        public static void Payment(double grandTotal) //Payment options. Lists the total, grand total, and the tax.
        {
            double tax = grandTotal - total;
            Console.WriteLine($"Here is your total without tax: {total:C} ");
            Console.WriteLine($"Your added tax at 6%: {tax:C}");
            Console.WriteLine($"Here is your grand total: {grandTotal:C}");
            Console.WriteLine();

            bool validPayment = false;
            while (!validPayment)
            {
                Console.WriteLine();
                Console.WriteLine("Here are our current payment methods:\n1.)Cash\n2.)Check\n3.)Credit");
                Console.Write("Please enter how you would like to pay: ");

                string paymentOption = Console.ReadLine().ToLower();
                if (paymentOption == "1" || paymentOption == "cash")
                {
                    validPayment = Validator.GetValidCash(grandTotal);//Method in validator class for getting the right amount of cash
                }
                else if (paymentOption == "2" || paymentOption == "check")
                {
                    validPayment = Validator.GetValidBankAccount();//Method in Validator class for getting a correct bank account.
                    Console.Write($"Your total charge is : {grandTotal:C}, which will reflect in your bank account within 1 business day.");
                }
                else if (paymentOption == "3" || paymentOption == "credit")
                {
                    validPayment = Validator.Mod10Check();//Method in validator class for getting the validated credit card
                    if (validPayment)
                    {
                        Console.Write($"You should see {grandTotal:C} charged to your Credit Card within 1 business day.");
                    }
                }
            }
        }

        public ArrayList LoadInventory()
        {
            try
            {
                fileIn = new StreamReader(INVENTORY);
            }
            catch (SystemException e)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR READING FILE: Country DB does not exist.");
                Console.WriteLine("Add a country (option #2) and the database will be created for you.");
                Console.WriteLine($"DETAILS: {e.Message}");
                return null;
            }

            ArrayList arrLst = new ArrayList();
            if (fileIn.EndOfStream)
            {
                Console.WriteLine("End of file reached. No records exist in the database! See the manager.");
                return null;
            }
            else
            {
                string input;
                while (fileIn.EndOfStream == false)
                {
                    input = fileIn.ReadLine();
                    if (input != "")
                    {
                        arrLst.Add(input.Trim());
                    }
                }

                fileIn.Close();
                return arrLst;
            }
        }

        public void UpdateInventory(ArrayList inv)
        {
            try
            {
                fileOut = new StreamWriter(INVENTORY, false);
            }
            catch (SystemException e)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR WRITING TO FILE: Please make sure the Inventory.txt exists or it has the proper permissions set. Check with systems administrator for help.");
                Console.WriteLine($"DETAILS: {e.Message}");
            }

            foreach (Product item in inv)
            {
                string str = $"{item.Name}\t{item.Category}\t{item.Description}\t{item.Price}\t{item.Quantity}";
                fileOut.WriteLine(str);
            }

            fileOut.Close();
        }
    }
}