using Ninkovic.Stefan.CSharpToPlant.Business.Api;
using Ninkovic.Stefan.CSharpToPlant.Common.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace Ninkovic.Stefan.CSharpToPlant.Business.Convert
{
    /// <summary>
    /// Converter for managing convertions associated to a Class-Diagran
    /// </summary>
    public class ClassDiagramConverter : IConvert
    {
        /// <summary>
        /// Goes through every assembly and creates a new instance of <see cref="ProjectAssembly"/> 
        /// including all types, methods and fields.
        /// </summary>
        /// <param name="assemblies">assemblies to go through</param>
        /// <returns>Collection of <see cref="ProjectAssembly"/></returns>
        public ICollection<ProjectAssembly> Convert(ICollection<Assembly> assemblies)
        {
            var projectAssemblies = new Collection<ProjectAssembly>();

            foreach (var assembly in assemblies)
            {
                var projectAssembly = new ProjectAssembly(assembly);

                foreach (var type in GetTypes(assembly))
                {
                    if (type == null) continue;
                    var projectType = new ProjectType(type);

                    // Adds every method in the type to the local ProjectType
                    foreach (var method in type.GetMethods())
                    {
                        var projectMethod = new ProjectMethod(method);
                        projectType.ProjectMethods.Add(projectMethod);
                    }

                    // Adds every constructor in the type to the local ProjectType
                    foreach (var constructor in type.GetConstructors())
                    {
                        var projectConstructor = new ProjectConstructor(constructor);
                        projectType.ProjectConstructors.Add(projectConstructor);
                    }

                    // Adds every field in the type to the local ProjectType
                    foreach (var field in type.GetFields())
                    {
                        var projectField = new ProjectField(field);
                        projectType.ProjectFields.Add(projectField);
                    }

                    projectAssembly.ProjectTypes.Add(projectType);
                }
                projectAssemblies.Add(projectAssembly);
            }

            return projectAssemblies;
        }

        /// <summary>
        /// Gets all types from a assembly
        /// </summary>
        /// <param name="assembly">assembly to fetch from</param>
        /// <returns>Collection of types referenced in the assembly</returns>
        public ICollection<Type> GetTypes(Assembly assembly)
        {
            try
            {
                return FilterAnonymousTypes(assembly.GetTypes());
            }
            // Catches the exception when a type is referenced which is not known in the asembly
            catch (ReflectionTypeLoadException e)
            {
                // Retrieves only the known types
                return FilterAnonymousTypes(e.Types);
            }
        }

        /// <summary>
        /// Checks each type in the collection if it exists and also if any special characters are included
        /// </summary>
        /// <param name="types">Collection to check</param>
        /// <returns>Filtered collection</returns>
        public ICollection<Type> FilterAnonymousTypes(Type[] types)
        {
            var correctTypes = new Collection<Type>();
            foreach (var type in types)
            {
                if (type == null) continue;
                else if (type.Name.Contains('<')) continue;
                else if (type.Name.Contains('>')) continue;
                else if (type.Name.Contains('\'')) continue;
                else if (type.Name.Contains('`')) continue;

                correctTypes.Add(type);
            }
            return correctTypes;
        }
    }
}
