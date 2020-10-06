using AutoFixture;
using Castle.Windsor;
using TestTools.WindsorMoqContainer;

namespace TestTools.UnitTest.UnitTestBase
{
    public abstract class UnitTestBase
    {
        public Fixture Fixture { get; }
        public IWindsorContainer Container { get;}

        public UnitTestBase(IWindsorContainer container = null)
        {
            Fixture = new Fixture();
            Container = container ?? new WindsorContainer()
                            .AsAutoMockContainerFromScannedSolutionAssemblies();
        }


    }
}
