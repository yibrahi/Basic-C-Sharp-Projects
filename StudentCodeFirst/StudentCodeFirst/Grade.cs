using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentCodeFirst
{
    // Represents a grade in the school database.
    public class Grade
    {
        // Primary key for the Grade table.
        public int GradeId { get; set; }

        // Stores the grade name.
        public string GradeName { get; set; }

        // Stores the section name.
        public string Section { get; set; }

        // Contains students associated with this grade.
        public ICollection<Student> Students { get; set; }
    }
}
