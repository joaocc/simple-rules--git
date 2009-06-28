using System;

namespace SimpleRules.Samples.Model
{
    public partial class Employee
    {
        public string Name { get; set; }

        public EmployeeStatus Status { get; set; }

        public PayType PayType { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime TerminationDate { get; set; }
    }
}
