using System.Reflection;
using Mono.Cecil;

namespace Lavallette
{
    public class TargetAssembly
    {
        readonly Assembly currentAssembly;
        ModuleDefinition moduleDefinition;

        public TargetAssembly(Assembly assembly)
        {
            this.currentAssembly = assembly;
            this.ReferencedAssemblies = this.currentAssembly.GetReferencedAssemblies();
        }

        public ModuleDefinition ModuleDefinition => moduleDefinition ??
                                                    (moduleDefinition = ModuleDefinition.ReadModule(this.currentAssembly.Location));

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

    }
}
