﻿using System.Linq;
using NUnit.Framework;
using SimpleRules.Testing.Core;
using NUnit.Framework.SyntaxHelpers;
using SimpleRules.UnitTests.Model.OrderEntry;

namespace SimpleRules.UnitTests.RuleTests
{
    [TestFixture]
    public class With_else_case : TestContext<RuleSpecs>
    {
        const string RULE_MESSAGE = "Order number must be 10 charactes long and contain no spaces";

        protected override void SetupState()
        {
            Order.Rules.Clear();

            Specs.Order.Status = OrderStatus.New;
            Specs.Order.Number = "1234567890";

            Order.Rules
                .Add(RULE_MESSAGE)
                    .When(o => o.Number.Length != 10)
                    .Then(o => o.Status = OrderStatus.OnHold)
                    .Else(o => o.Status = OrderStatus.ReadyToShip);
        }

        protected override void ExecuteMethodUnderTest()
        {
            Order.Rules.Evaluate(Specs.Order);
        }

        [Test]
        public void There_are_no_messages()
        {
            Assert.That(Order.Rules.Messages.Count(), Is.EqualTo(0));
        }

        [Test]
        public void Order_status_is_correct()
        {
            Assert.That(Specs.Order.Status, Is.EqualTo(OrderStatus.ReadyToShip));
        }
    }
}
