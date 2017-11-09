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
        private int qty;
        public int Qty
        {
            get { return qty; }
            set { qty = value; }
        }

        private long? transId;
        public long? TransId
        {
            get { return transId; }
        }

        public ShoppingCart ()
        {
            transId = null;
        }

        public void AddToCart (int selection, ArrayList inv)
        {
            bool quantityCheck = true;
            while (quantityCheck)
            {
                Product choice = (Product)inv[selection];
                Console.Write($"Please pick how many you would like of the {choice.Name} {choice.Category} package: ");
                int.TryParse(Console.ReadLine(), out int userQuantity);

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
        }

        public void GenerateCust ()
        {
            Console.WriteLine("Inside ShoppingCart.GenerateCust()");
        }

        public void QueryInventory ()
        {
            StreamReader fileIn = new StreamReader("Inventory.txt");
            Console.WriteLine("Inside ShoppingCart.QueryInventory()");
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
