using NUnit.Framework;

namespace SimpleRules.Testing.Core
{
    [TestFixture]
    public class TestContext<TSpec>
        where TSpec : class, new()
    {
        protected TSpec Specs { get; set; }

        protected virtual void SetupSpecs()
        {
            Specs = new TSpec();
        }

        protected virtual void SetupConfiguration()
        {
        }

        protected virtual void SetupState()
        {
        }

        protected virtual void SetupExpectations()
        {
        }

        protected virtual void ExecuteMethodUnderTest()
        {
        }

        protected virtual void SetupObservations()
        {
        }

        protected virtual void TeardownState()
        {
        }

        protected virtual void TeardownConfiguration()
        {
        }

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            SetupSpecs();
            SetupConfiguration();
            SetupState();
            SetupExpectations();
            ExecuteMethodUnderTest();
            SetupObservations();
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            TeardownState();
            TeardownConfiguration();
        }
    }
}
