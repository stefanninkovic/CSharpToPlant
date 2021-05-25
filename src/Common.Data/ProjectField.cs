﻿using System.Reflection;

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
    }
}
