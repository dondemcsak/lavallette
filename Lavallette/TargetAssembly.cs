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
        }

        public AssemblyName[] RefereenceAssemblyNames {
            get
            {
                return this.currentAssembly.GetReferencedAssemblies();
            }
        }
    }
}
