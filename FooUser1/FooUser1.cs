using System;
using System.Reflection;
using System.Runtime.Loader;

namespace jwms.LoadContextDemo
{
    public static class FooUser1
    {
        static FooUser1()
        {
            // 3. Static class ctor is actually called twice.
            //Console.WriteLine("FooUser1 ctor");
        }
        public static void PrintFooValue()
        {
            // Check which assembly this type is located in.
            //Console.WriteLine("FooUser1 AssemblyLoadContext: {0}", AssemblyLoadContext.GetLoadContext(typeof(FooUser1).Assembly));
            StaticFoo.PrintValue();
        }
    }
}
