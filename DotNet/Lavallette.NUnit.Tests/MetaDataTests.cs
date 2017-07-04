using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;

namespace Lavallette.NUnit.Tests
{
    [TestFixture]
    public class MetaDataTests
    {
        TargetAssembly tartgetAssembly;

        [OneTimeSetUp]
        public void TestSetup()
        {
            Console.Write(Assembly.GetExecutingAssembly().Location);
            string currentPath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var assembly = Assembly.LoadFrom(currentPath + @"\Test.DataAccess.dll");
            Assert.IsNotNull(assembly);
            this.tartgetAssembly = new TargetAssembly(assembly);
        }

        [Test]
        public void CanGetReferencedAssemblyNames()
        {
            
            Assert.IsNotNull(this.tartgetAssembly);
            Assert.True(this.tartgetAssembly.ReferencedAssemblies.Count() > 0);

        }

        [Test]
        public void CanLoadModuleDefintion()
        {
            Assert.IsNotNull(this.tartgetAssembly.ModuleDefinition);

            foreach (var type in this.tartgetAssembly.ModuleDefinition.Types)
            {
                foreach (var method in type.Methods)
                {
                    var resolvedMethod = method.Resolve();
                    resolvedMethod.Body.SimplifyMacros();
                    foreach (var instruction in resolvedMethod.Body.Instructions)
                    {
                        if (instruction.OpCode == OpCodes.Callvirt)
                        {
                            Console.WriteLine(instruction.Operand.ToString());
                            MethodReference reference = (MethodReference) instruction.Operand;
                            if (reference != null)
                            {
                                if (instruction.Previous.OpCode == OpCodes.Ldarg)
                                {
                                    var parameterDef = (ParameterDefinition) instruction.Previous.Operand;
                                    if (parameterDef != null)
                                    {
                                        Console.WriteLine(parameterDef.ParameterType.ToString()+"::"+reference.Name);
                                    }
                                }
                                Console.WriteLine(reference.DeclaringType.ToString()+"::"+reference.Name);
                            }

                            Console.WriteLine(resolvedMethod.ToString());
                        }
                    }
                }
            }
            
            
        }

    }
}
