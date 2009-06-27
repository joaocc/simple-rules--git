using System.Linq;
using NUnit.Framework;
using SimpleRules.Testing.Core;
using NUnit.Framework.SyntaxHelpers;
using SimpleRules.UnitTests.Model.OrderEntry;

namespace SimpleRules.UnitTests
{
    [TestFixture]
    public class When_rule_has_two_or_expressions : TestContext<RulesTestSpecs>
    {
        const string RULE_MESSAGE = "Order number must be 10 charactes long and contain no spaces or commas";

        protected override void SetupState()
        {
            Specs.InitializeInstance();

            Specs.Instance
                .Add(RULE_MESSAGE)
                    .When(o => o.Number.Length != 10)
                        .Or(o => o.Number.Contains(' '))
                        .Or(o => o.Number.Contains(','))
                    .Then(o => o.Status = OrderStatus.OnHold);
        }

        protected override void ExecuteMethodUnderTest()
        {
            Specs.RunRules("123456789", "1234 67890", "1234,6789");
        }

        [Test]
        public void Three_messages_exist()
        {
            Assert.That(Specs.Instance.Messages.Count(), Is.EqualTo(1));
        }

        [Test]
        public void All_messages_are_correct()
        {
            Assert.That(Specs.Instance.Messages.All(m => m == RULE_MESSAGE));
        }

        [Test]
        public void Order_status_is_correct()
        {
            Assert.That(Specs.Order.Status, Is.EqualTo(OrderStatus.OnHold));
        }
    }
}
