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
            StreamReader menuMaker = new StreamReader(FILENAME);
            ArrayList inventory = new ArrayList();
            ArrayList cart = new ArrayList();

            while (true)
            {

                string line = menuMaker.ReadLine();
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

                Product inventoryItem = new Product(name, category, description, price, quantity);
                quantity = inventoryItem.Quantity;
                inventory.Add(inventoryItem);

            }
            menuMaker.Close();

            foreach (Product i in inventory)
            {
                Console.WriteLine(i);
            }
        }
    }
}
