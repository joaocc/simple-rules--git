using System.Linq;
using NUnit.Framework;
using SimpleRules.Testing.Core;
using NUnit.Framework.SyntaxHelpers;
using SimpleRules.UnitTests.Model.OrderEntry;

namespace SimpleRules.UnitTests.RuleTests
{
    [TestFixture]
    public class When_rule_has_one_condition_and_one_action : TestContext<RuleSpecs>
    {
        const string RULE_MESSAGE = "Order must have at least one item.";

        protected override void SetupState()
        {
            Order.Rules
                .Add(RULE_MESSAGE)
                    .When(o => o.Items.Count() == 0)
                    .Then(o => o.Status = OrderStatus.OnHold);
        }

        protected override void ExecuteMethodUnderTest()
        {
            Order.Rules.Evaluate(Specs.Order);
        }

        [Test]
        public void Rule_list_contains_rule()
        {
            Assert.That(Order.Rules.ContainsRule(RULE_MESSAGE));
        }

        [Test]
        public void One_message_exists()
        {
            Assert.That(Order.Rules.Messages.Count(), Is.EqualTo(1));
        }

        [Test]
        public void Message_is_correct()
        {
            Assert.That(Order.Rules.Messages.All(m => m == RULE_MESSAGE));
        }

        [Test]
        public void Order_status_is_correct()
        {
            Assert.That(Specs.Order.Status, Is.EqualTo(OrderStatus.OnHold));
        }
    }
}
