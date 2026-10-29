namespace OperatorOverloadAssignment
{
    public class Employee
    {
        // Employee properties.
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Compare two employees using their Id values.
        public static bool operator ==(Employee employee1, Employee employee2)
        {
            return employee1.Id == employee2.Id;
        }

        // Check whether two employees have different Id values.
        public static bool operator !=(Employee employee1, Employee employee2)
        {
            return employee1.Id != employee2.Id;
        }

        // Override Equals so Employee comparisons are consistent.
        public override bool Equals(object obj)
        {
            Employee employee = obj as Employee;

            if (employee == null)
            {
                return false;
            }

            return Id == employee.Id;
        }

        // Return a hash code based on the employee's Id.
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}