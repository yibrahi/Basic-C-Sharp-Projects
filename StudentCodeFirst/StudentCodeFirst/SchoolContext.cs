using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace StudentCodeFirst
{
    // SchoolContext represents the connection between
    // the C# classes and the database.
    public class SchoolContext : DbContext
    {
        // Represents the Students table.
        public DbSet<Student> Students { get; set; }

        // Represents the Grades table.
        public DbSet<Grade> Grades { get; set; }
    }
}
