using System.Linq;
using NUnit.Framework;
using SimpleRules.Testing.Core;
using NUnit.Framework.SyntaxHelpers;
using System.Collections.Generic;
using SimpleRules.UnitTests.Model.OrderEntry;

namespace SimpleRules.UnitTests.RuleTests
{
    [TestFixture]
    public class With_and_case : TestContext<RuleSpecs>
    {
        const string RULE_MESSAGE = "You must order 10 or more of Product A.";

        protected override void SetupState()
        {
            Order.Rules.Clear();

            Specs.Order = new Order
            {
                Number = "1234567890",
                Status = OrderStatus.New,
                Items = new List<OrderItem>
                {
                    new OrderItem { Product = new Product { Name = "Product A" }, Quantity = 5m },
                    new OrderItem { Product = new Product { Name = "Product B" }, Quantity = 10m }
                }
            };

            Order.Rules
                .Add(RULE_MESSAGE)
                    .When(o => o.ContainsItem(i => i.Product.Name == "Product A"))
                    .And(o => o.SumItemQuantityWhere(i => i.Product.Name == "Product A") < 10m)
                    .Then(o => o.Status = OrderStatus.OnHold);
        }

        protected override void ExecuteMethodUnderTest()
        {
            Order.Rules.Evaluate(Specs.Order);
        }

        [Test]
        public void There_is_one_message()
        {
            Assert.That(Order.Rules.Messages.Count(), Is.EqualTo(1));
        }

        [Test]
        public void The_message_is_correct()
        {
            Assert.That(Order.Rules.Messages.First(), Is.EqualTo(RULE_MESSAGE));
        }

        [Test]
        public void Order_status_is_correct()
        {
            Assert.That(Specs.Order.Status, Is.EqualTo(OrderStatus.OnHold));
        }
    }
}
