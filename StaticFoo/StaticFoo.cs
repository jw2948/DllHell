using System;
using System.Reflection;
using System.Runtime.Loader;

namespace jwms.LoadContextDemo
{
    public static class StaticFoo
    {
        public static string value = "unset";
        public static void PrintValue()
        {
            Console.WriteLine("StaticFoo AssemblyLoadContext: {0}", AssemblyLoadContext.GetLoadContext(typeof(StaticFoo).Assembly));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("static value: {0}", value);
            Console.ResetColor();
        }
    }
}
