using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;

namespace Ninkovic.Stefan.CSharpToPlant.Business.Reflection
{
    /// <summary>
    /// Reflector for managing and maintaining assemblies
    /// </summary>
    public class AssemblyReflector
    {
        /// <summary>
        /// Gets all assemblies from a specific directory
        /// </summary>
        /// <param name="directoryPath">Directory to search for assemblies</param>
        /// <returns>Collection of assemblies included in the directory</returns>
        public ICollection<Assembly> GetAssembliesFromDirectory(string directoryPath)
        {
            var assemblies = new Collection<Assembly>();
            var files = Directory.GetFiles(directoryPath);

            // Checks each file if it is a Assembly-File
            foreach (var fileName in files)
            {
                if (Path.GetExtension(fileName).Equals(".dll"))
                {
                    assemblies.Add(Assembly.LoadFrom(fileName));
                }
            }
            return assemblies;
        }
    }
}
