using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace Ninkovic.Stefan.CSharpToPlant.Business.Convert
{
    internal class TypeHandler
    {
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
        private ICollection<Type> FilterAnonymousTypes(Type[] types)
        {
            var correctTypes = new Collection<Type>();
            foreach (var type in types)
            {
                if (type == null) continue;
                else if (type.Name.Contains("<")) continue;
                else if (type.Name.Contains(">")) continue;
                else if (type.Name.Contains("\'")) continue;
                else if (type.Name.Contains("`")) continue;

                correctTypes.Add(type);
            }
            return correctTypes;
        }
    }
}
