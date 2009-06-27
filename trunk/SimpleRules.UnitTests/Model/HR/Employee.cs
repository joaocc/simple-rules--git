using System;
using System.Linq.Expressions;

namespace SimpleRules.UnitTests.Model.HR
{
    public class Employee
    {
        public string Name { get; set; }
        public EmployeeStatus Status { get; set; }
        public PayType PayType { get; set; }

        #region Standins

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

        #endregion

        static Employee()
        {
            Rules = new RulesList<Employee>();
        }

        public static RulesList<Employee> Rules { get; set; }
    }
}
