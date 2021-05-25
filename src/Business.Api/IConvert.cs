using Ninkovic.Stefan.CSharpToPlant.Common.Data;
using System.Collections.Generic;

namespace Ninkovic.Stefan.CSharpToPlant.Business.Api
{
    public interface IConvert
    {
        string Convert(ICollection<ProjectAssembly> assemblies);
    }
}
