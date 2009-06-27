using SimpleRules.UnitTests.Model.OrderEntry;

namespace SimpleRules.UnitTests
{
    public class RulesTestSpecs
    {
        public RulesList<Order> Instance { get; set; }

        public Order Order { get; set; }

        public Rule<Order> ActualRule { get; set; }

        public RulesTestSpecs()
        {
            Order = new Order();
        }

        public void InitializeInstance()
        {
            Instance = new RulesList<Order>();
        }

        public void RunRules(params string[] orderNumbers)
        {
            foreach (var orderNumber in orderNumbers)
            {
                Order.Number = orderNumber;
                Instance.Evaluate(Order);
            }
        }
    }
}
