
namespace SimpleRules.UnitTests.Model.OrderEntry
{
    public partial class Order
    {
        public static RulesList<Order> Rules { get; set; }

        static Order()
        {
            Rules = new RulesList<Order>();
        }
    }
}
