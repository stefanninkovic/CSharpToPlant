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

        public override string ToString()
        {
            var visibility = string.Empty;
            var body = string.Empty;

            if (Value.IsPublic)
                visibility = "+";
            else if (Value.IsPrivate)
                visibility = "-";
            else if (Value.IsFamily)
                visibility = "#";

            for (int i = 0; i < Value.GetParameters().Length; i++)
            {
                body += $"{Value.GetParameters()[i].ParameterType} {Value.GetParameters()[i].Name} ";
                if (i != Value.GetParameters().Length - 1)
                {
                    body += ", ";
                }
            }

            return $"{ visibility } { Value.Name }({body}) : {Value.GetType()}";
        }
    }
}
