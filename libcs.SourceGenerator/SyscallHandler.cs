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
            public uint[] syscall;
            public IRQField EDI;
            public IRQField ESI;
            public IRQField EBP;
            public IRQField ESP;
            public IRQField EBX;
            public IRQField EDX;
            public IRQField ECX;
            public MethodDeclarationSyntax component;
        }
        public void Initialize(GeneratorInitializationContext context)
        {

        }

        public string Call(syscallData item) {
            var Args = new List<string>();
            var rand = new Random();

            var Output = new StringBuilder();
            if(item.EDI is not null) {
                var EDIArgname = Utils.RandomString();
                Args.Append(EDIArgname);
                Output.Append($@"var {EDIArgname} = ({item.EDI.FieldType}*) aContext.EDI");
            }
            if(item.ESI is not null) {
                var ESIArgname = Utils.RandomString();
                Args.Append(ESIArgname);
                Output.Append($@"var {ESIArgname} = ({item.ESI.FieldType}*) aContext.ESI");
            }
            if(item.EBP is not null) {
                var EBPArgname = Utils.RandomString();
                Args.Append(EBPArgname);
                Output.Append($@"var {EBPArgname} = ({item.EBP.FieldType}*) aContext.EBP");                
            }
            if(item.ESP is not null) {
                var ESPArgname = Utils.RandomString();
                Args.Append(ESPArgname);
                Output.Append($@"var {ESPArgname} = ({item.ESP.FieldType}*) aContext.ESP");                
            }
            if(item.EBX is not null) {
                var EBXArgname = Utils.RandomString();
                Args.Append(EBXArgname);
                Output.Append($@"var {EBXArgname} = ({item.EBX.FieldType}*) aContext.EBX");                
            }
            if(item.EDX is not null) {
                var EDXArgname = Utils.RandomString();
                Args.Append(EDXArgname);
                Output.Append($@"var {EDXArgname} = ({item.EDX.FieldType}*) aContext.EDX");                
            }
            if(item.ECX is not null) {
                var ECXArgname = Utils.RandomString();
                Args.Append(ECXArgname);
                Output.Append($@"var {ECXArgname} = ({item.ECX.FieldType}*) aContext.ECX");                
            }
            
            Output.Append(@$"{item.component.Identifier.Text}({string.Join(',', Args)});");

            return Output.ToString();
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

                foreach (syscallData item in GetSyscalls(context.Compilation))
                {
                    foreach (var syscall in item.syscall)
                    {
                        sb.Append($"case {syscall}:");
                        
                    }
                    sb.Append($@"{Call(item)}");
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
                .Select(x => {
                    return new syscallData() {
                        syscall = x.SysCall,
                        component = component,
                        EDI = x.EDI,
                        ESI = x.ESI,
                        EBP = x.EBP,
                        ESP = x.ESP,
                        EBX = x.EBX,
                        EDX = x.EDX,
                        ECX = x.ECX
                    };

                })
                .ToArray();
            if(attributes.Length == 0)
                return null;

            return attributes[0];

        }

    }
}
