using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;
using Moq;

namespace TestTools.WindsorMoqContainer
{
    /// <summary>
    /// ISubDedendencyResolver is a castle windsor interface,
    /// used when resolving
    /// </summary>
    internal class MockResolver : ISubDependencyResolver
    {
        private readonly IKernel kernel;

        public MockResolver(IKernel kernel)
            => this.kernel = kernel;
            
        
        /// <summary>
        ///  return true if the requested dependency is an interface
        /// </summary>
        /// <param name="context"></param>
        /// <param name="contextHandlerResolver"></param>
        /// <param name="model"></param>
        /// <param name="dependency"></param>
        /// <returns></returns>
        public bool CanResolve(CreationContext context, 
                                ISubDependencyResolver contextHandlerResolver, 
                                ComponentModel model, 
                                DependencyModel dependency)
        {
            return dependency.TargetType.IsInterface;
        }
        /// <summary>
        /// Resolves the requested type as an generic mock object
        /// </summary>
        /// <param name="context"></param>
        /// <param name="contextHandlerResolver"></param>
        /// <param name="model"></param>
        /// <param name="dependency"></param>
        /// <returns></returns>
        public object Resolve(CreationContext context, 
                                ISubDependencyResolver contextHandlerResolver, 
                                ComponentModel model, 
                                DependencyModel dependency)
        {
            var mockType = typeof(Mock<>).MakeGenericType(dependency.TargetType);
            return ((Mock) this.kernel.Resolve(mockType)).Object;
        }
    }
}
