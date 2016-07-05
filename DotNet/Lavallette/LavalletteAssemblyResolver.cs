using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Cecil;

namespace Lavallette
{
    public class LavalletteAssemblyResolver : DefaultAssemblyResolver
    {
        public override AssemblyDefinition Resolve(AssemblyNameReference name)
        {
            try
            {
                return base.Resolve(name);
            }
            catch (Exception)
            {
                // ignored
            }

            return null;

        }

        public override AssemblyDefinition Resolve(AssemblyNameReference name, ReaderParameters parameters)
        {
            try
            {
                return base.Resolve(name, parameters);
            }
            catch (Exception)
            {
                // ignored
            }

            return null;

        }

        public override AssemblyDefinition Resolve(string fullName)
        {
            try
            {
                return base.Resolve(fullName);
            }
            catch (Exception)
            {
                
                // ignored
            }

            return null;

        }

        public override AssemblyDefinition Resolve(string fullName, ReaderParameters parameters)
        {
            try
            {
                return base.Resolve(fullName, parameters);
            }
            catch (Exception)
            {
                
                //  ignored
            }

            return null;

        }
    }
}
