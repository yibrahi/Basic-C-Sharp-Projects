using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCodeFirst
{
    // Represents a student in the school database.
    public class Student
    {
        // Primary key for the Student table.
        public int StudentID { get; set; }

        // Stores the student's name.
        public string StudentName { get; set; }

        // Stores the student's date of birth.
        public DateTime? DateOfBirth { get; set; }

        // Stores a student photo as binary data.
        public byte[] Photo { get; set; }

        // Stores the student's height.
        public decimal Height { get; set; }

        // Stores the student's weight.
        public float Weight { get; set; }

        // Represents the grade associated with the student.
        public Grade Grade { get; set; }
    }
}
