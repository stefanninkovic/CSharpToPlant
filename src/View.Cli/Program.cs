using System;
using Ninkovic.Stefan.CSharpToPlant.Business.Convert;
using Ninkovic.Stefan.CSharpToPlant.Business.Convert.Convert;
using Ninkovic.Stefan.CSharpToPlant.Business.File;
using Ninkovic.Stefan.CSharpToPlant.Business.Reflection;

namespace View.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = "/Volumes/Projects/BitBucket/resta-api/build/debug/netcoreapp3.1/";
            var assemblies = new AssemblyReflector().GetAssembliesFromDirectory(path);
            var projectAssemblies = new ProjectAssemblyConverter().Convert(assemblies);
            var text = new ClassDiagramConverter().Convert(projectAssemblies);

            var isCreated = new FileWriter().CreateFile("/Users/stefan/Desktop/a/ClassDiagram.wsd", text);
            Console.WriteLine(isCreated);
        }
    }
}
