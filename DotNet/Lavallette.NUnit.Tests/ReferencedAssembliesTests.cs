using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Lavallette;
using Mono.Cecil;



namespace Lavallette.NUnit.Tests
{
    [TestFixture]
    public class ReferencedAssembliesTests
    {
        TargetAssembly tartgetAssembly;

        [OneTimeSetUp]
        public void TestSetup()
        {
            string currentPath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var assembly = Assembly.LoadFrom(currentPath + @"\Test.DataAccess.dll");
            Assert.IsNotNull(assembly);
            tartgetAssembly = new TargetAssembly(assembly);
            Assert.IsNotNull(tartgetAssembly);

        }

        [Test]
        public void UsesSystemDataTest()
        {
            Assert.IsNotNull(tartgetAssembly);
            Assert.True(tartgetAssembly.Uses(new AssemblyName("System.Data")));

        }
    }
}
