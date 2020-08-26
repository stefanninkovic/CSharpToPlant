using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ninkovic.Stefan.CSharpToPlant.Common.Data
{
    /// <summary>
    /// Local DTO for <see cref="Type"/>
    /// </summary>
    public class ProjectType
    {
        /// <summary>
        /// Associated methods in this type
        /// </summary>
        public ICollection<ProjectMethod> ProjectMethods { get; set; }

        /// <summary>
        /// Associated constructors in this type
        /// </summary>
        public ICollection<ProjectConstructor> ProjectConstructors { get; set; }

        /// <summary>
        /// Associated fields in this type
        /// </summary>
        public ICollection<ProjectField> ProjectFields { get; set; }

        /// <summary>
        /// Actual Type
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Actual Type</param>
        public ProjectType(Type type)
        {
            Type = type;
            ProjectMethods = new Collection<ProjectMethod>();
            ProjectConstructors = new Collection<ProjectConstructor>();
            ProjectFields = new Collection<ProjectField>();
        }

        public override string ToString()
        {
            var header = "\tclass " + Type.Name + " { " + Environment.NewLine;
            var footer = "\t} " + Environment.NewLine;
            string body = string.Empty;

            foreach (var projectField in ProjectFields)
            {
                body += "\t\t" + projectField + Environment.NewLine;
            }

            foreach (var projectConstructor in ProjectConstructors)
            {
                body += "\t\t" + projectConstructor + Environment.NewLine;
            }

            foreach (var projectMethod in ProjectMethods)
            {
                body += "\t\t" + projectMethod + Environment.NewLine;
            }

            return header + body + footer;
        }
    }
}
