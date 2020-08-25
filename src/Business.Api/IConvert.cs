using Ninkovic.Stefan.CSharpToPlant.Common.Data;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Ninkovic.Stefan.CSharpToPlant.Business.Api
{
    public interface IConvert
    {
        ICollection<ProjectAssembly> Convert(ICollection<Assembly> assemblies);
    }
}
