using System;
using System.Reflection;
using System.Runtime.Loader;

namespace jwms.LoadContextDemo
{
    public static class FooUser1
    {
        static FooUser1()
        {
            Console.WriteLine("FooUser1 ctor, AssemblyLoadContext: {0}", AssemblyLoadContext.GetLoadContext(typeof(FooUser1).Assembly));
        }
        public static void PrintFooValue()
        {
            Console.WriteLine("FooUser1 AssemblyLoadContext: {0}", AssemblyLoadContext.GetLoadContext(typeof(FooUser1).Assembly));
            StaticFoo.PrintValue();
        }
    }
}
