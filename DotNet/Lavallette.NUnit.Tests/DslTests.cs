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
    public class DslTests
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
        public void CanFindSqlConnectionOpenUses()
        {
            var referencedAssembly = Assembly.Load(new AssemblyName("System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            var referencedType = referencedAssembly.GetType("System.Data.SqlClient.SqlConnection");
            var referencedMethod = referencedType.GetMethod("Open");

            Assert.IsNotNull(this.tartgetAssembly);

            Assert.IsTrue(this.tartgetAssembly.Uses(referencedMethod));

        }
    }
}
