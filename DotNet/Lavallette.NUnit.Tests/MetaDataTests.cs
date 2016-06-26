using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Lavallette;

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
        }

    }
}
