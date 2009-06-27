using NUnit.Framework;
using SimpleRules.Testing.Core;
using NUnit.Framework.SyntaxHelpers;

namespace SimpleRules.UnitTests.RuleTests
{
    public class With_incomplete_rule : TestContext<RuleSpecs>
    {
        const string RULE_MESSAGE = "bogus rule #1";

        protected override void SetupState()
        {
            Specs.InitializeInstance();

            Specs.Instance
                .Add(RULE_MESSAGE);
        }

        protected override void ExecuteMethodUnderTest()
        {
            Specs.Instance.Evaluate(Specs.Order);
        }

        [Test]
        public void No_rules_exist()
        {
            Assert.That(Specs.Instance.Count(), Is.EqualTo(0));
        }
    }
}
