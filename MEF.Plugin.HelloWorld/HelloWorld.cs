using MEF.Contracts;
using System;
using System.ComponentModel.Composition;

namespace MEF.Plugin.HelloWorld
{
    [Export(typeof(IHelloWorld))]
    [ExportMetadata("Name", "HelloWorld Plugin")]
    public class HelloWorld : IHelloWorld
    {
        public void Say(string message)
        {
            Console.WriteLine(message);
        }
    }
}
