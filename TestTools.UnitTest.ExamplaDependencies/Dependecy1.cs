using System;

namespace TestTools.UnitTest.ExampleDependencies
{
    public class Dependency1 : IDependency1
    {
        public  void Message(string message)
        {
            throw new NotImplementedException();
        }
    }
}
