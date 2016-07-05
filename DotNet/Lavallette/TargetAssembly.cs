using System.Reflection;
using Mono.Cecil;

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

    }
}
