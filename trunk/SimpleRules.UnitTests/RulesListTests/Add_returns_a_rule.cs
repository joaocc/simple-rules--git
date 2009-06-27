using NUnit.Framework;
using SimpleRules.Testing.Core;
using SimpleRules.UnitTests.Model;
using NUnit.Framework.SyntaxHelpers;
using SimpleRules.UnitTests.Model.OrderEntry;

namespace SimpleRules.UnitTests.RulesListTests
{
    [TestFixture]
    public class Add_returns_a_rule : TestContext<RulesListSpecs>
    {
        object Value { get; set; }

        protected override void SetupState()
        {
            Specs.InitializeInstance();
        }

        protected override void ExecuteMethodUnderTest()
        {
            Value = Specs.Instance.Add("Some random rule");
        }

        [Test]
        public void Rule_is_correct_type()
        {
            Assert.That(Value, Is.InstanceOfType(typeof(Rule<Order>)));
        }
    }
}
