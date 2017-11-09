using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject
{
    class Product
    {
        private string name;
        private string category;
        private string description;
        private double price;
        private int quantity;

        public Product(string name, string category, string description, double price, int quantity)
        {
            this.name = name;
            this.category = category;
            this.description = description;
            this.price = price;
            this.quantity = quantity;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        public string  Description
        {
            get { return description; }
            set { description = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public override string ToString()
        {
            return $"{name,-20} | {category,-15} | {description,-30} | {price,10:C} | {quantity,7:n0} |"; 
        }
    }
}