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
        Assembly assembly;

        [OneTimeSetUp]
        public void TestSetup()
        {
            Console.Write(Assembly.GetExecutingAssembly().Location);
            string currentPath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            assembly = Assembly.LoadFrom(currentPath + @"\Test.DataAccess.dll");
            Assert.IsNotNull(assembly);
        }

        [Test]
        public void CanGetReferencedAssemblyNames()
        {
            var tartgetAssembly = new TargetAssembly(assembly);
            Assert.IsNotNull(tartgetAssembly);
            Assert.True(tartgetAssembly.RefereenceAssemblyNames.Count() > 0);

        }
    }
}
