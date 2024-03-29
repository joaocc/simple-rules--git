﻿using NUnit.Framework;
using SimpleRules.Testing.Core;
using NUnit.Framework.SyntaxHelpers;
using SimpleRules.UnitTests.Model.OrderEntry;

namespace SimpleRules.UnitTests.RuleTests
{
    [TestFixture]
    public class When_returns_a_when_statement : TestContext<RuleSpecs>
    {
        object Value { get; set; }

        protected override void ExecuteMethodUnderTest()
        {
            Value = Order.Rules
                .Add("Some random rule")
                .When(o => o.Number == "1");
        }

        [Test]
        public void Rule_is_correct_type()
        {
            Assert.That(Value, Is.InstanceOfType(typeof(WhenStatement<Order>)));
        }
    }
}
