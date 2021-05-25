using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ninkovic.Stefan.CSharpToPlant.Common.Data
{
    /// <summary>
    /// Local DTO for <see cref="Value"/>
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
        public Type Value { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Actual Type</param>
        public ProjectType(Type type)
        {
            Value = type;
            ProjectMethods = new Collection<ProjectMethod>();
            ProjectConstructors = new Collection<ProjectConstructor>();
            ProjectFields = new Collection<ProjectField>();
        }
    }
}
