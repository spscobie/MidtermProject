using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject
{
    class GetInventory
    {
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

    }
}