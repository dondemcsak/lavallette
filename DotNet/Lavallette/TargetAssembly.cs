using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Mono.Cecil;

namespace Lavallette
{
    public class TargetAssembly
    {
        Assembly currentAssembly;
        ModuleDefinition moduleDefinition;

        public TargetAssembly(Assembly assembly)
        {
            this.currentAssembly = assembly;
            this.ReferencedAssemblies = this.currentAssembly.GetReferencedAssemblies();
        }

        public ModuleDefinition ModuleDefinition
        {
            get {
                if (moduleDefinition == null)
                {
                    moduleDefinition =  ModuleDefinition.ReadModule(this.currentAssembly.Location);
                }
                return moduleDefinition;
            }

        }

        public AssemblyName[] ReferencedAssemblies { get; private set; }

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
