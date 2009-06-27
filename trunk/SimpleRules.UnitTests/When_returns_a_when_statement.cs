using NUnit.Framework;
using SimpleRules.Testing.Core;
using SimpleRules.UnitTests.Model;
using NUnit.Framework.SyntaxHelpers;
using SimpleRules.UnitTests.Model.OrderEntry;

namespace SimpleRules.UnitTests
{
    [TestFixture]
    public class When_returns_a_when_statement : TestContext<RulesTestSpecs>
    {
        object Value { get; set; }

        protected override void SetupState()
        {
            Specs.InitializeInstance();
        }

        protected override void ExecuteMethodUnderTest()
        {
            Value = Specs.Instance
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
