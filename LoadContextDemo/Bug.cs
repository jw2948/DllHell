using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace jwms.LoadContextDemo
{
    public class Bug
    {
        public static Type MyFooUser1;

        static Bug()
        {
            string fooUser1Path = @"D:\repos\DllHell\LoadContextDemo\bin\Debug\netcoreapp3.1\jwms.LoadContextDemo.FooUser1.dll";
            string staticFooPath = @"D:\repos\DllHell\LoadContextDemo\bin\Debug\netcoreapp3.1\jwms.LoadContextDemo.StaticFoo.dll";

            // 1. Bug free.
            Assembly fooUser1Assembly = Assembly.LoadFrom(fooUser1Path);

            // 2. AssemblyLoadContext bug.
            //Assembly fooUser1Assembly = Assembly.LoadFile(fooUser1Path);

            AssemblyLoadContext.GetLoadContext(fooUser1Assembly).LoadFromAssemblyPath(staticFooPath);

            MyFooUser1 = fooUser1Assembly.GetType("jwms.LoadContextDemo.FooUser1");

            // 4. Can't tell type difference from type info. E.g. FullName. But they are indeed different.
            //Console.WriteLine("MyFooUser1: {0}", MyFooUser1.FullName);
            //Console.WriteLine("FooUser1: {0}", typeof(FooUser1).FullName);
            //Console.WriteLine("MyFooUser1 == FooUser1? {0}", MyFooUser1 == typeof(FooUser1));
        }

        public static void FooUser1_PrintFooValue()
        {
            Console.WriteLine("Print from Bug:");
            MyFooUser1.GetMethod("PrintFooValue").Invoke(null, null);
        }
    }
}
