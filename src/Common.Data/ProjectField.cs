using System.Reflection;

namespace Ninkovic.Stefan.CSharpToPlant.Common.Data
{
    /// <summary>
    /// Local DTO for <see cref="FieldInfo"/>
    /// </summary>
    public class ProjectField
    {
        /// <summary>
        /// Actual Field-Information
        /// </summary>
        public FieldInfo Value { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">Actual Field-Information</param>
        public ProjectField(FieldInfo value)
        {
            Value = value;
        }

        public override string ToString()
        {
            var visiblity = string.Empty;

            if (Value.IsPublic)
                visiblity = "+";
            else if (Value.IsPrivate)
                visiblity = "-";
            else if (Value.IsFamily)
                visiblity = "#";
            return $"{visiblity} {Value.Name} : {Value.GetType()}";
        }
    }
}
