using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.UnitTest.ExampleDependencies
{
    public class Dependency2 : IDependency2
    {
        public  void Message(string message)
        {
            throw new NotImplementedException();
        }
    }
}
