using NUnit.Framework;
using SimpleRules.Testing.Core;
using NUnit.Framework.SyntaxHelpers;

namespace SimpleRules.UnitTests
{
    public class When_true_action_is_missing : TestContext<RulesTestSpecs>
    {
        const string RULE_MESSAGE = "bogus rule #1";

        protected override void SetupState()
        {
            Specs.InitializeInstance();

            Specs.Instance
                .Add(RULE_MESSAGE)
                .When(o => o.Number == "1");
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
