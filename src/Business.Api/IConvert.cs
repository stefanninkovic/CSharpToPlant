using System;
using System.Collections.Generic;
using System.Reflection;

namespace Ninkovic.Stefan.CSharpToPlant.Business.Api
{
    public interface IConvert
    {
        ICollection<DateTime> Convert(ICollection<Assembly> assemblies);
    }
}
