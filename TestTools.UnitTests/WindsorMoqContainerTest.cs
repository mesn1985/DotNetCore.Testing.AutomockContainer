using Castle.Windsor;
using Moq;
using TestTools.UnitTest.ExampleDependencies;
using TestTools.WindsorMoqContainer;
using Xunit;

namespace TestTools.TestForThisSolution.UnitTests
{
    public class WindsorMoqContainerTest
    {
        [Fact]
        public void can_resolve_1_Object_Object_should_be_assignable_to_IRoot_Interface()
        {
            var container = new WindsorContainer().AsAutoMockContainerFromTypeDependencies<RootClass>();

            var sut = container.Resolve<RootClass>();

            Assert.IsAssignableFrom<IRoot>(sut);
        }
        [Fact]
        public void Dependencies_are_Mocks_Message_Method_are_Called_On_dependency1()
        {
            var container = new WindsorContainer().AsAutoMockContainerFromTypeDependencies<RootClass>();
            var sut = container.Resolve<RootClass>();
            string expectedMessage = "Message As expected";

            sut.PassMessageToDependency1(expectedMessage);

            container
                .Resolve<Mock<IDependency1>>()
                .Verify(c => c.Message(expectedMessage));
        }
        [Fact]
        public void Dependencies_are_Mocks_Message_Method_are_Called_On_dependency2()
        {
            var container = new WindsorContainer().AsAutoMockContainerFromTypeDependencies<RootClass>();
            var sut = container.Resolve<RootClass>();
            string expectedMessage = "Message As expected";

            sut.PassMessageToDependency2(expectedMessage);

            container
                .Resolve<Mock<IDependency2>>()
                .Verify(c => c.Message(expectedMessage));
        }
        
    }
}
