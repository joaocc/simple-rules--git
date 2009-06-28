using SimpleRules.UnitTests.Model.OrderEntry;
using SimpleRules.UnitTests.Model.HR;

namespace SimpleRules.UnitTests.RuleTests
{
    public class RuleSpecs
    {
        public Order Order { get; set; }
        public Employee Employee { get; set; }

        public RuleSpecs()
        {
            Order = new Order();
            Employee = new Employee();
        }
    }
}
