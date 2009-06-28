using System;
using System.Collections.Generic;
using SimpleRules.Samples.Model;

namespace SimpleRules.Samples.MethodGroups
{
    public static class Sample1
    {
        #region Setup

        static IEnumerable<Employee> Employees { get; set; }

        static Sample1()
        {
            Employees = new List<Employee>
            {
                new Employee { Name = "Fred", PayType = PayType.Hourly, Status = EmployeeStatus.Active },
                new Employee { Name = "Barney", PayType = PayType.Hourly, Status = EmployeeStatus.Active },
                new Employee { Name = "Mr. Slate", PayType = PayType.Salary, Status = EmployeeStatus.Active },
            };
        }

        #endregion

        public static void Run()
        {
            ReportResults("Before:");

            Employee.Rules
                .Add( "Terminate all hourly employees" )
                .When( Employee.is_hourly )
                .And( Employee.is_active )
                .Then( Employee.terminate );

            foreach (var employee in Employees)
            {
                Employee.Rules.Evaluate(employee);
            }

            foreach (var message in Employee.Rules.Messages)
            {
                Console.WriteLine(message);
            }

            ReportResults("After:");
        }

        #region Private Methods

        private static void ReportResults(string label)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(label);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            foreach (var employee in Employees)
            {
                Console.WriteLine("{0} : {1} : {2}",
                    employee.Name, employee.PayType, employee.Status);
            }

            Console.WriteLine();
        }

        #endregion
    }
}
