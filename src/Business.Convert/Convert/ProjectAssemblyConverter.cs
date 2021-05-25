using Ninkovic.Stefan.CSharpToPlant.Common.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace Ninkovic.Stefan.CSharpToPlant.Business.Convert
{
    /// <summary>
    /// Converter for managing convertions associated to a Class-Diagran
    /// </summary>
    public class ProjectAssemblyConverter
    {
        private readonly TypeHandler _typeHandler;

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectAssemblyConverter()
        {
            _typeHandler = new TypeHandler();
        }

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

                foreach (var type in _typeHandler.GetAssemblyTypes(assembly))
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
    }
}
