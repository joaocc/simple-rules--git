using SimpleRules.UnitTests.Model.OrderEntry;

namespace SimpleRules.UnitTests.RulesListTests
{
    public class RulesListSpecs
    {
        public RulesList<Order> Instance { get; set; }

        public Order Order { get; set; }

        public RulesListSpecs()
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
