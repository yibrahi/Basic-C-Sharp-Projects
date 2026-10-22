using System;

namespace MethodAssignment
{
    // This class contains the method.
    public class MathOperations
    {
        // This void method accepts two integers as parameters.
        public void PerformOperation(int firstNumber, int secondNumber)
        {
            // Perform a math operation on the first integer.
            int result = firstNumber * 2;

            // Display the result of the math operation.
            Console.WriteLine("The first number multiplied by 2 is: " + result);

            // Display the second integer to the screen.
            Console.WriteLine("The second number is: " + secondNumber);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the MathOperations class.
            MathOperations mathObject = new MathOperations();

            // Call the method by passing in two numbers.
            mathObject.PerformOperation(10, 20);

            // Call the method again by specifying the parameters by name.
            mathObject.PerformOperation(firstNumber: 15, secondNumber: 30);

            Console.ReadLine();
        }
    }
}