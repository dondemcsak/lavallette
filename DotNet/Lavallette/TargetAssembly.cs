using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Lavallette
{
    public class TargetAssembly
    {
        Assembly currentAssembly;

        public TargetAssembly(Assembly assembly)
        {
            this.currentAssembly = assembly;
            this.ReferencedAssemblies = this.currentAssembly.GetReferencedAssemblies();
        }

        public AssemblyName[] ReferencedAssemblies { get; private set; }

        public bool Uses(AssemblyName assemblyName)
        {

            foreach (AssemblyName refAssembly in this.ReferencedAssemblies) {
                if(refAssembly.Name == assemblyName.Name)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
