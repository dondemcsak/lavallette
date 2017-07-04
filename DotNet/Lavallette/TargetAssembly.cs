using System;
using System.Reflection;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;

namespace Lavallette
{
    public class TargetAssembly
    {
        readonly Assembly currentAssembly;
        ModuleDefinition moduleDefinition;
        static readonly LavalletteAssemblyResolver Resolver = new LavalletteAssemblyResolver();
        ReaderParameters assemblyReaderParameters = new ReaderParameters
        {
            AssemblyResolver = Resolver
        };

        public TargetAssembly(Assembly assembly)
        {
            this.currentAssembly = assembly;
            this.ReferencedAssemblies = this.currentAssembly.GetReferencedAssemblies();
        }

        public ModuleDefinition ModuleDefinition => moduleDefinition ??
                                                    (moduleDefinition = ModuleDefinition.ReadModule(this.currentAssembly.Location,this.assemblyReaderParameters));

        public AssemblyName[] ReferencedAssemblies { get; }

        public bool Uses(AssemblyName assemblyName)
        {

            foreach (AssemblyName refAssembly in this.ReferencedAssemblies) {
                if(AssemblyName.ReferenceMatchesDefinition(refAssembly, assemblyName))
                {
                    return true;
                }
            }

            return false;
        }

        public bool Uses(MethodInfo info)
        {
            if (info == null)
            {
                throw new NullReferenceException("MethodInfo is Null");
            }

            if (info.DeclaringType == null) return false;
            foreach (var type in this.ModuleDefinition.Types)
            {
                foreach (var method in type.Methods)
                {
                    var resolvedMethod = method.Resolve();
                    resolvedMethod.Body.SimplifyMacros();
                    foreach (var instruction in resolvedMethod.Body.Instructions)
                    {
                        if (instruction.OpCode == OpCodes.Callvirt)
                        {
                            MethodReference reference = (MethodReference) instruction.Operand;
                            if (reference != null)
                            {
                                if (instruction.Previous.OpCode == OpCodes.Ldarg)
                                {
                                    var parameterDef = (ParameterDefinition) instruction.Previous.Operand;
                                    if (parameterDef != null)
                                    {
                                        if (parameterDef.ParameterType.Name == info.DeclaringType.Name)
                                        {
                                            if (reference.Name == info.Name)
                                                return true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        
    }
}
