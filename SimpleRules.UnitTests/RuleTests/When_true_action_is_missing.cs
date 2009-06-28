using NUnit.Framework;
using SimpleRules.Testing.Core;
using NUnit.Framework.SyntaxHelpers;
using SimpleRules.UnitTests.Model.OrderEntry;

namespace SimpleRules.UnitTests.RuleTests
{
    public class When_true_action_is_missing : TestContext<RuleSpecs>
    {
        const string RULE_MESSAGE = "bogus rule #1";

        protected override void SetupState()
        {
            Order.Rules.Clear();

            Order.Rules.Add(RULE_MESSAGE)
                .When(o => o.Number == "1");
        }

        protected override void ExecuteMethodUnderTest()
        {
            Order.Rules.Evaluate(Specs.Order);
        }

        [Test]
        public void No_rules_exist()
        {
            Assert.That(Order.Rules.Count(), Is.EqualTo(0));
        }
    }
}
