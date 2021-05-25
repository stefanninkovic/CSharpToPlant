using System;
using System.Collections.Generic;
using Ninkovic.Stefan.CSharpToPlant.Business.Api;
using Ninkovic.Stefan.CSharpToPlant.Common.Data;

namespace Ninkovic.Stefan.CSharpToPlant.Business.Convert.Convert
{
    public class ClassDiagramConverter : IConvert
    {
        private readonly TypeHandler _typeHandler;

        public ClassDiagramConverter()
        {
            _typeHandler = new TypeHandler();
        }

        public string Convert(ICollection<ProjectAssembly> assemblies)
        {
            string entireText = "@startuml ClassDiagram";
            foreach (var assembly in assemblies)
            {
                string assemblyText = $"\t{ assembly.Assembly.GetName().Name } {{";
                foreach (var type in assembly?.ProjectTypes)
                {
                    string typeText = $"{ type.Value.Name } {{ { Environment.NewLine }";
                    foreach (var field in type?.ProjectFields)
                    {
                        string fieldText = "\t\t";
                        if (field.Value.IsPublic)
                            fieldText += "+ ";
                        else
                            fieldText += "- ";

                        fieldText += $"{ field.Value.Name } : { field.Value.FieldType.Name }";
                        typeText += fieldText;
                    }

                    foreach (var constructor in type?.ProjectConstructors)
                    {
                        string constructorText = "\t\t";
                        if (constructor.Value.IsPublic)
                            constructorText += "+ ";
                        else
                            constructorText += "- ";

                        constructorText += $"{ constructor.Value.Name }(";

                        var parameters = _typeHandler.GetMethodParameterTypes(constructor.Value);
                        for (int i = 0; i < parameters?.Length; i++)
                        {
                            constructorText += $"{ parameters[i].ParameterType.Name } { parameters[i].Name }";
                            if (i != parameters.Length - 1)
                                constructorText += ", ";
                            else
                                constructorText += ")";
                        }

                        typeText += constructorText;
                    }

                    foreach (var method in type?.ProjectMethods)
                    {
                        string methodText = "\t\t";
                        if (method.Value.IsPublic)
                            methodText += "+ ";
                        else
                            methodText += "- ";

                        var parameters = _typeHandler.GetMethodParameterTypes(method.Value);
                        methodText += $"{ method.Value.Name }(";

                        for (int i = 0; i < parameters?.Length; i++)
                        {
                            methodText += $"{ parameters[i].Name } { parameters[i].Name }";
                            if (i != parameters.Length - 1)
                                methodText += ", ";
                            else
                                methodText += ")";
                        }

                        typeText += methodText;
                    }
                    assemblyText += $"{ typeText }{ Environment.NewLine }}}{ Environment.NewLine }";
                }
                entireText += $"{ assemblyText }{ Environment.NewLine }}}{ Environment.NewLine }";
            }
            return entireText;
        }
    }
}
