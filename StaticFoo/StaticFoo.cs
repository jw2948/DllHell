using System;
using System.Reflection;
using System.Runtime.Loader;

namespace jwms.LoadContextDemo
{
    public static class StaticFoo
    {
        public static string value = "unset";

        static StaticFoo()
        {
            // 3. Static class ctor is actually called twice.
            //Console.WriteLine("StaticFoo ctor");
        }

        public static void PrintValue()
        {
            // 6. The modified one is in default AssemblyLoadContext.
            //Console.WriteLine("StaticFoo AssemblyLoadContext: {0}", AssemblyLoadContext.GetLoadContext(typeof(StaticFoo).Assembly));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("static value: {0}", value);
            Console.ResetColor();
        }
    }
}
