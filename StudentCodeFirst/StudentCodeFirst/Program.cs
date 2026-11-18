using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentCodeFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the SchoolContext.
            using (var ctx = new SchoolContext())
            {
                // Create a new Student object.
                var student = new Student()
                {
                    StudentName = "Bill"
                };

                // Add the new student to the Students table.
                ctx.Students.Add(student);

                // Save the student to the database.
                ctx.SaveChanges();

                // Display confirmation.
                Console.WriteLine("Student successfully added to the database.");
            }

            // Keep the console open.
            Console.ReadLine();
        }
    }
}
