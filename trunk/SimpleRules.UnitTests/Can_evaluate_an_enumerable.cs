using System.Linq;
using NUnit.Framework;
using SimpleRules.Testing.Core;
using SimpleRules.UnitTests.Model;
using NUnit.Framework.SyntaxHelpers;
using System.Collections.Generic;
using SimpleRules.UnitTests.Model.OrderEntry;

namespace SimpleRules.UnitTests
{
    [TestFixture]
    public class Can_evaluate_an_enumerable : TestContext<RulesTestSpecs>
    {
        const string RULE_MESSAGE = "Orders with the number 3 suck.";

        IEnumerable<Order> Orders { get; set; }

        protected override void SetupState()
        {
            Specs.InitializeInstance();

            Orders = new List<Order>
            {
                new Order { Number = "1" },
                new Order { Number = "2" },
                new Order { Number = "3" }
            };

            Specs.Instance
                .Add(RULE_MESSAGE)
                    .When(o => o.Number == "3")
                    .Then(o => o.Status = OrderStatus.OnHold);
        }

        protected override void ExecuteMethodUnderTest()
        {
            foreach (var order in Orders)
            {
                Specs.Instance.Evaluate(order);
            }
        }

        [Test]
        public void One_message_exists()
        {
            Assert.That(Specs.Instance.Messages.Count(), Is.EqualTo(1));
        }

        [Test]
        public void The_message_is_correct()
        {
            Assert.That(Specs.Instance.Messages.First(), Is.EqualTo(RULE_MESSAGE));
        }

        [Test]
        public void Order_status_is_correct()
        {
            Assert.That(Orders.Where(o => o.Number == "3").First().Status, Is.EqualTo(OrderStatus.OnHold));
        }
    }
}
