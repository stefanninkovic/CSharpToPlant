using System.Reflection;

namespace Ninkovic.Stefan.CSharpToPlant.Common.Data
{
    /// <summary>
    /// Local DTO for <see cref="MethodInfo"/>
    /// </summary>
    public class ProjectMethod
    {
        /// <summary>
        /// Actual Method-Information
        /// </summary>
        public MethodInfo Value { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">Actual Method-Information</param>
        public ProjectMethod(MethodInfo value)
        {
            Value = value;
        }
    }
}
