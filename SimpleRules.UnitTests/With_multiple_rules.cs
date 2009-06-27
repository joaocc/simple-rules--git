using System.Linq;
using NUnit.Framework;
using SimpleRules.Testing.Core;
using NUnit.Framework.SyntaxHelpers;
using SimpleRules.UnitTests.Model.OrderEntry;

namespace SimpleRules.UnitTests
{
    [TestFixture]
    public class With_multiple_rules : TestContext<RulesTestSpecs>
    {
        const string RULE1_MESSAGE = "Order number must be 10 charactes long.";
        const string RULE2_MESSAGE = "Order must contain at least one item.";

        protected override void SetupState()
        {
            Specs.InitializeInstance();

            Specs.Order.Number = "123456789";

            Specs.Instance
                .Add(RULE1_MESSAGE)
                    .When(o => o.Number.Length != 10)
                    .Then(o => o.Status = OrderStatus.OnHold);

            Specs.Instance
                .Add(RULE2_MESSAGE)
                    .When(o => o.Items.Count() == 0)
                    .Then(o => o.Status = OrderStatus.OnHold);
        }

        protected override void ExecuteMethodUnderTest()
        {
            Specs.Instance.Evaluate(Specs.Order);
        }

        [Test]
        public void Two_messages_exist()
        {
            Assert.That(Specs.Instance.Messages.Count(), Is.EqualTo(2));
        }

        [Test]
        public void Message_list_contains_message_for_rule_1()
        {
            Assert.That(Specs.Instance.Messages.Contains(RULE1_MESSAGE));
        }

        [Test]
        public void Message_list_contains_message_for_rule_2()
        {
            Assert.That(Specs.Instance.Messages.Contains(RULE2_MESSAGE));
        }

        [Test]
        public void Order_status_is_correct()
        {
            Assert.That(Specs.Order.Status, Is.EqualTo(OrderStatus.OnHold));
        }
    }
}
