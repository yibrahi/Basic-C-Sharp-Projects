using System;

namespace PackageExpress
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Display the welcome message.
            Console.WriteLine("Welcome to Package Express. Please follow the instructions below.");

            // Ask the user to enter the package weight.
            Console.WriteLine("Please enter the package weight:");

            // Read the user's input and convert it from a string to a decimal number.
            decimal weight = Convert.ToDecimal(Console.ReadLine());

            // Check whether the package weight is greater than 50.
            if (weight > 50)
            {
                // Display an error message if the package is too heavy.
                Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");

                // End the program immediately.
                return;
            }

            // Ask the user to enter the package width.
            Console.WriteLine("Please enter the package width:");

            // Read and convert the width entered by the user.
            decimal width = Convert.ToDecimal(Console.ReadLine());

            // Ask the user to enter the package height.
            Console.WriteLine("Please enter the package height:");

            // Read and convert the height entered by the user.
            decimal height = Convert.ToDecimal(Console.ReadLine());

            // Ask the user to enter the package length.
            Console.WriteLine("Please enter the package length:");

            // Read and convert the length entered by the user.
            decimal length = Convert.ToDecimal(Console.ReadLine());

            // Add all three dimensions together.
            decimal totalDimensions = width + height + length;

            // Check whether the total dimensions are greater than 50.
            if (totalDimensions > 50)
            {
                // Display an error message if the package is too large.
                Console.WriteLine("Package too big to be shipped via Package Express.");

                // End the program immediately.
                return;
            }

            // Multiply width, height, length and weight together then divide by 100.
            decimal quote = (width * height * length * weight) / 100;

            // Display the shipping quote formatted as a dollar amount.
            Console.WriteLine("Your estimated total for shipping this package is: $" + quote);

            // Thank the user.
            Console.WriteLine("Thank you!");
        }
    }
}
