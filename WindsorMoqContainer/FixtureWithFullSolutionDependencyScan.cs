using System.Collections.Generic;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Moq;


namespace TestTools.WindsorMoqContainer
{
    internal class FixtureWithFullSolutionDependencyScan : IWindsorInstaller
    {
        private IEnumerable<string> _assembliesFullName;

        public FixtureWithFullSolutionDependencyScan(IEnumerable<string> assembliesFullName)
        {
            this._assembliesFullName = assembliesFullName;
        }
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
           container.Kernel.Resolver.AddSubResolver(
               
               new MockResolver(
                   container.Kernel
                   ));

           container.Register(
               Component.For(typeof(Mock<>)));

           foreach (var assemblyName in _assembliesFullName)
           {
               container.Register(Classes.FromAssemblyNamed(assemblyName)
                                         .Pick()
                                         .WithServiceSelf()
                                         .LifestyleTransient());
           }
           

        }

    }
}
