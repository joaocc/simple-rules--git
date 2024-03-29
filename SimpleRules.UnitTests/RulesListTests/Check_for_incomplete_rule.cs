﻿using NUnit.Framework;
using SimpleRules.Testing.Core;
using NUnit.Framework.SyntaxHelpers;
using System.Collections.Generic;
using System.Linq;
using SimpleRules.UnitTests.Model.OrderEntry;

namespace SimpleRules.UnitTests.RulesListTests
{
    public class Check_for_incomplete_rule : TestContext<RulesListSpecs>
    {
        IEnumerable<Rule<Order>> Rules { get; set; }

        protected override void SetupState()
        {
            Specs.InitializeInstance();

            Specs.Instance
                .Add("bogus rule");
        }

        protected override void ExecuteMethodUnderTest()
        {
            Rules = Specs.Instance.FindIncompleteRules();
        }

        [Test]
        public void Incomplete_rule_exists()
        {
            Assert.That(Rules.Count(), Is.EqualTo(1));
        }
    }
}
