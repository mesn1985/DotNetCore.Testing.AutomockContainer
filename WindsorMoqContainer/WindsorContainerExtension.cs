using System.Diagnostics;
using Castle.Windsor;

namespace TestTools.WindsorMoqContainer
{
    public static class WindsorContainerExtension
    {
        public static IWindsorContainer AsAutoMockContainerFromScannedSolutionAssemblies(this IWindsorContainer container)
        {
            //TODO find a better solution to implicitly get callers type
            var callerType = new StackFrame(1).GetMethod().DeclaringType;
            
            var solutionAssembliesWithFullName = callerType.GetSolutionAssemblyNames();

            container.Install(new FixtureWithFullSolutionDependencyScan(solutionAssembliesWithFullName));

            return container;
        }
        public static IWindsorContainer AsAutoMockContainerFromTypeDependencies<T>(this IWindsorContainer container)
            => container.Install(new Fixture<T>());

        
        

    }
}
