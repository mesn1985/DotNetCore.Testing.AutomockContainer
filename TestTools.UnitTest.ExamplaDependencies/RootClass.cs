namespace TestTools.UnitTest.ExampleDependencies
{
    public class RootClass : IRoot
    {
        private IDependency1 _dependency1;
        private IDependency2 _dependency2;

        public RootClass(IDependency1 dependency1, IDependency2 dependecy2)
        {
            this._dependency1 = dependency1;
            this._dependency2 = dependecy2;
        }


        public void PassMessageToDependency1(string message)
            => _dependency1.Message(message);
        public void PassMessageToDependency2(string message)
            => _dependency2.Message(message);

    }
}
