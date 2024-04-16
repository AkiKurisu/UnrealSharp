﻿using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;

namespace UnrealSharp.SourceGenerators;

public class SingleDelegateBuilder : DelegateBuilder
{
    public override void StartBuilding(StringBuilder stringBuilder, INamedTypeSymbol delegateSymbol, INamedTypeSymbol classSymbol)
    {
        GenerateGetInvoker(stringBuilder, delegateSymbol);
        GenerateConstructor(stringBuilder, classSymbol);

        //Check if the class has an Invoker method already
        if (!classSymbol.GetMembers("Invoker").Any())
        {
            GenerateInvoke(stringBuilder, delegateSymbol);
        }
    }
    
    void GenerateConstructor(StringBuilder stringBuilder, INamedTypeSymbol classSymbol)
    {
        stringBuilder.AppendLine($"    public {classSymbol.Name}() : base()");
        stringBuilder.AppendLine("    {");
        stringBuilder.AppendLine("    }");
        stringBuilder.AppendLine();

        stringBuilder.AppendLine($"    public {classSymbol.Name}(DelegateData data) : base(data)");
        stringBuilder.AppendLine("    {");
        stringBuilder.AppendLine("    }");
        stringBuilder.AppendLine();
        
        stringBuilder.AppendLine($"    public {classSymbol.Name}(UnrealSharp.CoreUObject.Object targetObject, Name functionName) : base(targetObject, functionName)");
        stringBuilder.AppendLine("    {");
        stringBuilder.AppendLine("    }");
        stringBuilder.AppendLine();
    }
    
}