using System;
using System.Linq.Expressions;

namespace SimpleRules.UnitTests.Model.HR
{
    public partial class Employee
    {
        public static RulesList<Employee> Rules { get; set; }

        static Employee()
        {
            Rules = new RulesList<Employee>();
        }

        public static Expression<Func<Employee, bool>> is_hourly
        {
            get { return e => e.PayType == PayType.Hourly; }
        }

        public static Expression<Func<Employee, bool>> is_salary
        {
            get { return e => e.PayType == PayType.Salary; }
        }

        public static Expression<Func<Employee, bool>> is_active
        {
            get { return e => e.Status == EmployeeStatus.Active; }
        }

        public static Expression<Func<Employee, bool>> is_terminated
        {
            get { return e => e.Status == EmployeeStatus.Terminated; }
        }

        public static Action<Employee> terminate
        {
            get { return e => e.Status = EmployeeStatus.Terminated; }
        }
    }
}
