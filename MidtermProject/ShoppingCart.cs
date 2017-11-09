using System;
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
        StreamReader fileIn;
        StreamWriter fileOut;

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

        private long? transId;
        public long? TransId
        {
            get { return transId; }
        }

        //public ShoppingCart ()
        //{
            //transId = null;
        //}

        public ShoppingCart()
        {
            ArrayList cart = new ArrayList();
            ArrayList quantities = new ArrayList();
            userCart = cart;
            Quantity = quantities;
        }

        public static void AddtoCart(ShoppingCart cart, Product selection,int quantity)
        {
            cart.userCart.Add(selection);
            cart.quantity.Add(quantity);
        }

        public static void GetCart(ShoppingCart cart)
        {
            Console.WriteLine("ItemName\t\tCategory\tPrice\tQuantity");
            int qty = 0;
            foreach (Product item in cart.UserCart)
            {
                Console.WriteLine("*======*======*======*======*======*======*======*======*");
                Console.WriteLine($"{item.Name}\t\t{item.Category}\t{item.Price:C}\t{cart.Quantity[qty]}");
                Console.WriteLine("*======*======*======*======*======*======*======*======*");
            }
        }

        public double GetTotal()
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
            return total;
        }

        public void GetQuantity (int selection, ArrayList menu)
        {
            bool quantityCheck = true;
            while (quantityCheck)
            {
                Product choice = (Product)menu[selection];
                Console.Write($"Please pick how many you would like of the {choice.Name} {choice.Category} package: ");
                int stock = choice.Quantity;
                int.TryParse(Console.ReadLine(), out int userQuantity);

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
        }

        public static ArrayList CurrentInventory(string filename)
        {
            StreamReader inventory = new StreamReader(filename);
            ArrayList menu = new ArrayList();
            bool repeat = true;
            while (repeat)
            {
                string name;
                string category;
                string description;
                double price;
                int quantity;

                string line = inventory.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    break;
                }

                string[] itemInfo = line.Split('\t');
                /************ Set attributes for display ****************/
                name = itemInfo[0];
                category = itemInfo[1];
                description = itemInfo[2];
                double.TryParse(itemInfo[3], out price);
                int.TryParse(itemInfo[4], out quantity);
                /********************************************************/

                Product menuItem = new Product(name, category, description, price, quantity);
                quantity = menuItem.Quantity;
                menu.Add(menuItem);

            }
            inventory.Close();



            return menu;
        }

        public ArrayList LoadInventory ()
        {
            fileIn = new StreamReader("Inventory.txt");

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

        public void GenerateCust()
        {
            Console.WriteLine("Inside ShoppingCart.GenerateCust()");
        }

        public void RemoveFromCart()
        {
            Console.WriteLine("Inside ShoppingCart.RemoveFromCart()");
        }

        public void ReturnItem ()
        {
            Console.WriteLine("Inside ShoppingCart.ReturnItem()");
        }

        public void TrackCustomer ()
        {
            Console.WriteLine("Inside ShoppingCart.TrackCustomer()");
        }

        public void VoidTrans()
        {
            Console.WriteLine("Inside ShoppingCart.VoidTrans()");
        }
    }
}
