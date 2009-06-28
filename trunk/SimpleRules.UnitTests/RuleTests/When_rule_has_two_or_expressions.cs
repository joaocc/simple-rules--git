using System.Linq;
using NUnit.Framework;
using SimpleRules.Testing.Core;
using NUnit.Framework.SyntaxHelpers;
using SimpleRules.UnitTests.Model.OrderEntry;

namespace SimpleRules.UnitTests.RuleTests
{
    [TestFixture]
    public class When_rule_has_two_or_expressions : TestContext<RuleSpecs>
    {
        const string RULE_MESSAGE = "Order number must be 10 charactes long and contain no spaces or commas";

        protected override void SetupState()
        {
            Order.Rules.Clear();

            Order.Rules
                .Add(RULE_MESSAGE)
                    .When(o => o.Number.Length != 10)
                        .Or(o => o.Number.Contains(' '))
                        .Or(o => o.Number.Contains(','))
                    .Then(o => o.Status = OrderStatus.OnHold);
        }

        protected override void ExecuteMethodUnderTest()
        {
            Specs.Order.Number = "123 567,9";
            Order.Rules.Evaluate(Specs.Order);
        }

        [Test]
        public void Three_messages_exist()
        {
            Assert.That(Order.Rules.Messages.Count(), Is.EqualTo(1));
        }

        [Test]
        public void All_messages_are_correct()
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
