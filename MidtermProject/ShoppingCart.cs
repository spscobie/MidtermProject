using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject
{
    class ShoppingCart
    {
        private long? transId;
        public long? TransId
        {
            get { return transId; }
        }

        public ShoppingCart ()
        {
            transId = null;
        }

        public void AddToCart ()
        {
            Console.WriteLine("Inside ShoppingCart.AddFromCart()");
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
