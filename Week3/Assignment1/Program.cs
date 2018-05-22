using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter date of Birth in format DD/MM/YYYY: ");
            string input = Console.ReadLine();
            DateTime dt;
            while (!DateTime.TryParseExact(input, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
            {
                Console.WriteLine("Invalid date, please retry");
                input = Console.ReadLine();
            }

            Customer customer1 = new Customer(name, dt);
            int age = customer1.Age;
            bool isDiscount = customer1.EligbleToDiscount;

            Console.WriteLine("name: " + customer1.Name + " \nage:" + age + " \ndiscount:" + isDiscount.ToString());
            Console.ReadKey();
        }
    }
}
