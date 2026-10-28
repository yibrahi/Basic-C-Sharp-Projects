using System;

namespace PolymorphismAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create an Employee object but store it using the IQuittable interface type.
            // This demonstrates polymorphism.
            IQuittable employee = new Employee()
            {
                // Assign a first name to the Employee object.
                FirstName = "John",

                // Assign a last name to the Employee object.
                LastName = "Smith"
            };

            // Call the Quit() method through the IQuittable interface.
            employee.Quit();

            // Keep the console window open until the user presses Enter.
            Console.ReadLine();
        }
    }
}
