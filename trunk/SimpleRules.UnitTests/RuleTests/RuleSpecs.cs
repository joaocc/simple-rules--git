using SimpleRules.UnitTests.Model.OrderEntry;

namespace SimpleRules.UnitTests.RuleTests
{
    public class RuleSpecs
    {
        public RulesList<Order> Instance { get; set; }

        public Order Order { get; set; }

        public RuleSpecs()
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
