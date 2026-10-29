using System;

namespace OperatorOverloadAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create the first Employee object.
            Employee employee1 = new Employee();

            // Assign values to the first employee's properties.
            employee1.Id = 101;
            employee1.FirstName = "John";
            employee1.LastName = "Smith";

            // Create the second Employee object.
            Employee employee2 = new Employee();

            // Assign values to the second employee's properties.
            employee2.Id = 101;
            employee2.FirstName = "Sarah";
            employee2.LastName = "Johnson";

            // Compare the two Employee objects using the overloaded == operator.
            bool areEqual = employee1 == employee2;

            // Display the result of the == comparison.
            Console.WriteLine("Are the two employees equal? " + areEqual);

            // Compare the two Employee objects using the overloaded != operator.
            bool areNotEqual = employee1 != employee2;

            // Display the result of the != comparison.
            Console.WriteLine("Are the two employees different? " + areNotEqual);

            // Keep the console window open.
            Console.ReadLine();
        }
    }
}
