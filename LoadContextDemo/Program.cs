using System;
using System.Reflection;
using System.Runtime.Loader;
using jwms.LoadContextDemo;

namespace LoadContextDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 5.2. Shows where it's loaded to right after it's loaded.
            //AppDomain.CurrentDomain.AssemblyLoad += new AssemblyLoadEventHandler(MyAssemblyLoadEventHandler);

            FooUser1.PrintFooValue();
            Bug.FooUser1_PrintFooValue();

            StaticFoo.value = "hello";

            FooUser1.PrintFooValue();
            Bug.FooUser1_PrintFooValue();

            // 5.1. Shows all the loaded assemblies.
            //PrintLoadedAssemblies();
        }

        static void PrintLoadedAssemblies()
        {
           Console.WriteLine("------------------LOADED ASSEMBLIES:");
           foreach (AssemblyLoadContext alc in AssemblyLoadContext.All)
            {
                Console.WriteLine("AssemblyLoadContext {0}:", alc.Name);
                foreach (Assembly a in alc.Assemblies)
                {
                    Console.WriteLine("  {0}", a.FullName);
                }
            }
           Console.WriteLine("------------------");
        }

        static void MyAssemblyLoadEventHandler(object sender, AssemblyLoadEventArgs args)
        {
           Console.WriteLine("ASSEMBLY LOADED: {0}\nAssemblyLoadContext: {1}\n",
               args.LoadedAssembly.FullName,
               AssemblyLoadContext.GetLoadContext(args.LoadedAssembly).Name);
        }
    }
}
