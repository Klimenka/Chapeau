using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Customer
    {
        private string name;
        private DateTime BirthDate;
        public DateTime RegistrationDate
        { get; }

        
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (value != "")
                { name = value; }
            }
        }
        public int Age
        {
            get
            {
                return (DateTime.Today.Year - BirthDate.Year);
            }

        }

        public bool EligbleToDiscount
        {
            get
            {
                if (RegistrationDate.AddYears(1) <= DateTime.Today)
                {
                    return true;
                }
                return false;
            }

        }

        //constructor
        public Customer(string name, DateTime birthDate)
        {
            this.Name = name;
            this.BirthDate = birthDate;
            this.RegistrationDate = DateTime.Today;
        }




    }
}
