using NUnit.Framework;
using SimpleRules.Testing.Core;
using NUnit.Framework.SyntaxHelpers;

namespace SimpleRules.UnitTests.RulesListTests
{
    public class When_a_rule_is_removed_which_doesnt_exist : TestContext<RulesListSpecs>
    {
        const string RULE_MESSAGE = "bogus rule #1";

        protected override void SetupState()
        {
            Specs.InitializeInstance();
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
