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
            Specs.InitializeInstance();

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

            Specs.Instance
                .Add(RULE_MESSAGE)
                    .When(o => o.ContainsItem(i => i.Product.Name == "Product A"))
                    .And(o => o.SumItemsBy(i => i.Product.Name == "Product A") < 10m)
                    .Then(o => o.Status = OrderStatus.OnHold);
        }

        protected override void ExecuteMethodUnderTest()
        {
            Specs.Instance.Evaluate(Specs.Order);
        }

        [Test]
        public void There_is_one_message()
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
            Assert.That(Specs.Order.Status, Is.EqualTo(OrderStatus.OnHold));
        }
    }
}
