using System;
using System.Reflection;
using jwms.LoadContextDemo;

namespace LoadContextDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //AppDomain.CurrentDomain.AssemblyLoad += new AssemblyLoadEventHandler(MyAssemblyLoadEventHandler);

            FooUser1.PrintFooValue();
            Bug.FooUser1_PrintFooValue();

            StaticFoo.value = "hello";

            FooUser1.PrintFooValue();
            Bug.FooUser1_PrintFooValue();

            PrintLoadedAssemblies(AppDomain.CurrentDomain);
        }

        static void PrintLoadedAssemblies(AppDomain domain)
        {
           Console.WriteLine("------------------LOADED ASSEMBLIES:");
           foreach (Assembly a in domain.GetAssemblies()) {
                if (a.FullName.StartsWith("jwms"))
                {
                    Console.WriteLine(a.FullName);
                }
           }
           Console.WriteLine("------------------");
        }

        static void MyAssemblyLoadEventHandler(object sender, AssemblyLoadEventArgs args)
        {
           Console.WriteLine("ASSEMBLY LOADED: " + args.LoadedAssembly.FullName);
        }
    }
}
