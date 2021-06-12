using libcs.common.Attribute;

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace libcs.SourceGenerator
{
    [Generator]
    public class SyscallHandler : ISourceGenerator
    {
        public class syscallData {
            public byte[] syscall;
            public MethodDeclarationSyntax component;
        }
        public void Initialize(GeneratorInitializationContext context)
        {

        }

        public void Execute(GeneratorExecutionContext context)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"
            using System;
            using static Cosmos.Core.INTs;
            namespace libcs.core {
                public static class SyscallHandler
                {
                    static byte interrupt;
                    public static void Init(byte interrupt) {
                        SyscallHandler.interrupt = interrupt;
                        SetIntHandler(interrupt, InterruptHandler);
                    }

                    public unsafe static void InterruptHandler(ref IRQContext aContext)
                    {
                        if (aContext.Interrupt != interrupt) return;
                        switch(aContext.EAX)
                        {
            ");

                foreach (var item in GetSyscalls(context.Compilation))
                {
                    foreach (var syscall in item.syscall)
                    {
                        sb.Append($"case {syscall}:");
                        
                    }
                    sb.Append($@"
                    Console.WriteLine({item.component.GetLocation()});
                    Console.WriteLine({item.component.GetLocation().SourceTree});
                    Console.WriteLine({item.component.GetReference()});
                    
                    ");
                    sb.Append("break;");
                }

            sb.Append(@"
                        default:
                        }
                    }

                }
            }");

            
            context.AddSource(
                "libcs.core.generator.syscallhandler",
                SourceText.From(sb.ToString(), Encoding.UTF8)
            );
        }

        private static ImmutableArray<syscallData> GetSyscalls(Compilation compilation)
        {
            // Get all classes
            IEnumerable<SyntaxNode> allNodes = compilation.SyntaxTrees.SelectMany(s => s.GetRoot().DescendantNodes());
            IEnumerable<MethodDeclarationSyntax> allClasses = allNodes
                .Where(d => d.IsKind(SyntaxKind.MethodDeclaration))
                .OfType<MethodDeclarationSyntax>();

            ImmutableArray<syscallData> output = allClasses
                .Select(component => TryGetSyscall(compilation, component))
                .Where(syscall => syscall is not null)
                .Cast<syscallData>()
                .ToImmutableArray();

            return output;
        
        }


        private static syscallData TryGetSyscall(Compilation compilation, MethodDeclarationSyntax component)
        {
            var attributes = component.AttributeLists
                .SelectMany(x => x.Attributes)
                .Where(attr => attr.GetType() == typeof(SyscallAttribute))
                .Cast<SyscallAttribute>()
                .Select(x => x.SysCall)
                .ToArray();
            if(attributes.Length == 0)
                return null;
            return new syscallData() {
                syscall = attributes,
                component = component
            };

        }

    }
}
