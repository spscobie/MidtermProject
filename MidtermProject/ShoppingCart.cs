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

        public static void ListInventory(ArrayList inv)
        {
            if (inv != null)
            {
                string name;
                string category;
                string description;
                double price;
                int qty;

                Console.WriteLine(new string('+', 110)); //header
                for (int item = 0; item < inv.Count; item++)
                {
                    string[] itemInfo = ((string)inv[item]).Split('\t');

                    /************ Set attributes for display ****************/
                    name = itemInfo[0].Trim();
                    category = itemInfo[1].Trim();
                    description = itemInfo[2].Trim();
                    double.TryParse(itemInfo[3].Trim(), out price);
                    int.TryParse(itemInfo[4], out qty);
                    /********************************************************/

                    Console.WriteLine($"| {item + 1, -4} | {name, -20} | {category, -15} | {description, -30} | {price, 10:C} | {qty, 7:n0} |");
                }

                Console.WriteLine(new string('+', 110)); //footer
                Console.WriteLine();
            }
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
