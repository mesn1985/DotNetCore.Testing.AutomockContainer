# DotNetCore.Testing.AutomockContainer

**Still in testing** **Still in progress**

A container that scans all classes in the assembly tree and delivers them with all  injectable dependencies mocked.

Windsor castle is the used IOC container.

The automock container works by scanning all the dependecies from the member calling the exetension method
AsAutoMockContainerFromScannedSolutionAssemblies.

To use.

1. import the assembly TestTools.WindsorMoqContainer
2. create a new Windsor container and call the AsAutoMockContainerFromScannedSolutionAssemblies
   from that instance. E.g "new WindsorContainer().AsAutoMockContainerFromScannedSolutionAssemblies();"


