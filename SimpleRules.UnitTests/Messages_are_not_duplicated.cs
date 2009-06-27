using System.Linq;
using NUnit.Framework;
using SimpleRules.Testing.Core;
using SimpleRules.UnitTests.Model;
using NUnit.Framework.SyntaxHelpers;
using System.Collections.Generic;
using SimpleRules.UnitTests.Model.HR;

namespace SimpleRules.UnitTests
{
    [TestFixture]
    public class Messages_are_not_duplicated : TestContext<RulesTestSpecs>
    {
        const string RULE_MESSAGE = "Terminate all hourly employees.";

        IEnumerable<Employee> Employees { get; set; }

        protected override void SetupState()
        {
            Employees = new List<Employee>
            {
                new Employee { Name = "Fred", PayType = PayType.Hourly, Status = EmployeeStatus.Active },
                new Employee { Name = "Barney", PayType = PayType.Hourly, Status = EmployeeStatus.Active },
                new Employee { Name = "Mr. Slate", PayType = PayType.Salary, Status = EmployeeStatus.Active },
            };

            Employee.Rules
                .Add(RULE_MESSAGE)
                .When(Employee.is_hourly)
                .And(Employee.is_active)
                .Then(Employee.terminate);
        }

        protected override void ExecuteMethodUnderTest()
        {
            foreach (var employee in Employees)
            {
                Employee.Rules.Evaluate(employee);
            }
        }

        [Test]
        public void There_is_one_message()
        {
            Assert.That(Employee.Rules.Messages.Count(), Is.EqualTo(1));
        }

        [Test]
        public void The_message_is_correct()
        {
            Assert.That(Employee.Rules.Messages.First(), Is.EqualTo(RULE_MESSAGE));
        }

        [Test]
        public void Two_employees_are_terminated()
        {
            Assert.That(Employees.Where(e => e.Status == EmployeeStatus.Terminated).Count() , Is.EqualTo(2));
        }

        [Test]
        public void Fred_is_terminated()
        {
            Assert.That(Employees.Where(e => e.Name == "Fred").Single().Status, Is.EqualTo(EmployeeStatus.Terminated));
        }

        [Test]
        public void Barney_is_terminated()
        {
            Assert.That(Employees.Where(e => e.Name == "Barney").Single().Status, Is.EqualTo(EmployeeStatus.Terminated));
        }
    }
}
