using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MidtermProject
{
    class Customer
    {
        private const string CUSTFILE = "Customers.txt";
        private StreamWriter fileOut;

        private string firstName;


        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }


        private string lastName;


        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private string address;


        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private string city;


        public string City
        {
            get { return city; }
            set { city = value; }
        }

        private string state;


        public string State
        {
            get { return state; }
            set { state = value; }
        }

        private string zip;


        public string Zip
        {
            get { return zip; }
            set { zip = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public Customer()
        {
            FirstName = "";
            LastName = "";
            Address = "";
            City = "";
            State = "";
            Zip = "";
            Email = "";

        }

        public void GetCustomer()
        {
            Customer cust = new Customer();

            Console.Write("First Name: ");
            cust.FirstName = Console.ReadLine();
            Console.Write("Last Name: ");
            cust.LastName = Console.ReadLine();
            Console.Write("Address: ");
            cust.Address = Console.ReadLine();
            Console.Write("City: ");
            cust.City = Console.ReadLine();
            Console.Write("State: ");
            cust.State = Console.ReadLine();
            Console.Write("Zip Code: ");
            cust.Zip = Console.ReadLine();
            Console.Write("Email Address: ");
            cust.Email = Console.ReadLine();

            UpdateCustDb(cust);

        }

        private void UpdateCustDb(Customer cust)
        {
            try
            {
                fileOut = new StreamWriter(CUSTFILE, true);
            }
            catch (SystemException e)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR WRITING TO FILE: Please make sure the Customers.txt exists or it has the proper permissions set. Check with systems administrator for help.");
                Console.WriteLine($"DETAILS: {e.Message}");
            }
            string str = $"\r\n{cust.FirstName}|{cust.LastName}|{cust.Address}|{cust.City}|{cust.State}|{cust.Zip}|{cust.Email}";
            fileOut.Write(str);
            fileOut.Close();
        }
    }
}