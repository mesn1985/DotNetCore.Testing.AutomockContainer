using System.Collections.Generic;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Moq;


namespace TestTools.WindsorMoqContainer
{
    internal class Fixture<T> : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
           container.Kernel.Resolver.AddSubResolver(
               
               new MockResolver(
                   container.Kernel
                   ));

           container
               .Register(
               Component.For(typeof(Mock<>)))
                    .Register(
                                Classes.FromAssemblyContaining(typeof(T))
                                     .Pick()
                                     .WithServiceSelf()
                                     .LifestyleTransient()
                                     );
        }

    }
}
