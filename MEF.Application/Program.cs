using MEF.Contracts;
using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;

namespace MEF.Application
{
    class Program
    {
        public CompositionContainer Container { get; }

        public Program()
        {            
            var catalog = new AggregateCatalog();
            var pluginDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Plugins", "netstandard2.0");
            catalog.Catalogs.Add(new DirectoryCatalog(pluginDirectoryPath));

            Container = new CompositionContainer(catalog);

            try
            {
                Container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }

        static void Main(string[] args)
        {
            var program = new Program();

            var plugin = program.Container.GetExport<IHelloWorld>();
            plugin.Value.Say("Hello World");
        }
    }
}
