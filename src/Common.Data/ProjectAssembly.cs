using System;
using System.Collections.Generic;
using System.Reflection;

namespace Ninkovic.Stefan.CSharpToPlant.Common.Data
{
    /// <summary>
    /// Local DTO for <see cref="Assembly"/>
    /// </summary>
    public class ProjectAssembly
    {
        /// <summary>
        /// Associated Types in this assembly
        /// </summary>
        public ICollection<ProjectType> ProjectTypes { get; set; }

        /// <summary>
        /// Actual Assembly
        /// </summary>
        public Assembly Assembly { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="assembly">actual assembly</param>
        public ProjectAssembly(Assembly assembly)
        {
            Assembly = assembly;
        }

        public override string ToString()
        {
            var header = "package" + Assembly.GetName() + " { ";
            var footer = "} " + Environment.NewLine;
            string body = string.Empty;

            foreach (var projectType in ProjectTypes)
            {
                body += projectType + Environment.NewLine;
            }

            return header + body + footer;
        }
    }
}
