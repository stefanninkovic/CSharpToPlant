using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace Ninkovic.Stefan.CSharpToPlant.Business.Convert
{
    internal class TypeHandler
    {
        public Type[] GetAssemblyTypes(Assembly assembly)
        {
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types;
            }
        }

        public ParameterInfo[] GetMethodParameterTypes(MethodBase methodBase)
        {
            try
            {
                return methodBase.GetParameters();
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: { e.Message }");
                return null;
            }
        }
    }
}
