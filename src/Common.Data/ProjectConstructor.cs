using System.Reflection;

namespace Ninkovic.Stefan.CSharpToPlant.Common.Data
{
    /// <summary>
    /// Local DTO for <see cref="ConstructorInfo"/>
    /// </summary>
    public class ProjectConstructor
    {
        /// <summary>
        /// Actual value of <see cref="ProjectConstructor"/>
        /// </summary>
        public ConstructorInfo Value { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">Actual value of <see cref="ProjectConstructor"/></param>
        public ProjectConstructor(ConstructorInfo value)
        {
            Value = value;
        }
    }
}
