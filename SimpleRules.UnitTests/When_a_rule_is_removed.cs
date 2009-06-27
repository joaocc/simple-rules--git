using NUnit.Framework;
using SimpleRules.Testing.Core;
using NUnit.Framework.SyntaxHelpers;
using SimpleRules.UnitTests.Model.OrderEntry;

namespace SimpleRules.UnitTests
{
    public class When_a_rule_is_removed : TestContext<RulesTestSpecs>
    {
        const string RULE_MESSAGE = "bogus rule #1";

        protected override void SetupState()
        {
            Specs.InitializeInstance();

            Specs.Instance
                .Add(RULE_MESSAGE)
                    .When(o => o.Number.Length != 10)
                    .Then(o => o.Status = OrderStatus.OnHold);
        }

        protected override void ExecuteMethodUnderTest()
        {
            Specs.Instance.Remove(RULE_MESSAGE);
        }

        [Test]
        public void No_rules_exist()
        {
            Assert.That(Specs.Instance.Count(), Is.EqualTo(0));
        }
    }
}
