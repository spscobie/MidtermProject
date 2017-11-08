using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject
{
    class Program
    {
        static void Main(string[] args)
        {

            bool repeat = true;
            while (repeat)
            {
                Console.WriteLine(Validator.GetValidSelection());
                Console.WriteLine("Would you like to add this item to your shopping cart? (Y/N): ");
                bool addCart = Validator.YesNo();
                Console.WriteLine($"You added {0} ${0}to your shopping cart");

                Console.WriteLine("Would you like to continue shopping? (Y/N)");
                bool shopAgain = Validator.YesNo();

                Console.WriteLine("Would you like to checkout? (Y/N)");
                bool checkOut = Validator.YesNo();

                Console.WriteLine(Validator.Mod10Check());
            }

        }
    }
}
