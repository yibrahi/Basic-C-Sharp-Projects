using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismAssignment
{
    public class Employee : IQuittable
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public void Quit()
        {

            Console.WriteLine(FirstName + " " + LastName + " has quit the company.");
        }
    }
}
