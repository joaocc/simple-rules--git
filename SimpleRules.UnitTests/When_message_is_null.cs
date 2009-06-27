using NUnit.Framework;
using SimpleRules.Testing.Core;
using System.Collections.Generic;
using SimpleRules.UnitTests.Model.OrderEntry;
using System;

namespace SimpleRules.UnitTests
{
    public class When_message_is_null : TestContext<RulesTestSpecs>
    {
        IEnumerable<Rule<Order>> Rules { get; set; }
        Rule<Order> Rule { get; set; }

        protected override void SetupState()
        {
            Specs.InitializeInstance();
        }

        [Test]
        [ExpectedException(
            ExceptionType = typeof(ArgumentException),
            ExpectedMessage = "Parameter: message is a required.")]
        public void Add_Throws_argument_exception()
        {
            Specs.Instance.Add(null);
        }
    }
}
