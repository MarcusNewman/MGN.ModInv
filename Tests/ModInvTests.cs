using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace MGN.ModInv.Tests
{
    [TestClass]
    public class ModInvTests
    {
        [TestMethod]
        public void MGN_ModInv_dllShouldExist()
        {
            GetAssembly();
        }

        private static Assembly GetAssembly()
        {
            return ReflectionAssert.AssemblyExists("MGN.ModInv.dll");
        }

        [TestMethod]
        public void ModInvTypeShouldExist()
        {

            GetModInvType();
        }

        private static Type GetModInvType()
        {
            var assembly = GetAssembly();
            return assembly.TypeExists("ModInv", "MGN");
        }

        [TestMethod]
        public void CalculateMethodShouldExist()
        {
            GetCalculateMethod();

        }

        private static MethodInfo GetCalculateMethod()
        {
            var modInvType = GetModInvType();
            return modInvType.MethodExists("Calculate",
                shouldBeStatic: true,
                shouldReturnType: typeof(int?),
                shouldBeAnExtentionMethod: false,
                parameterTypesAndNames: new System.Collections.Generic.List<Tuple<Type, string>> {
                    Tuple.Create(typeof(int), "value"),
                    Tuple.Create(typeof(int), "modulus") });
        }

        [TestMethod]
        public void inv15mod26shouldBe7()
        {
            var value = 15;
            var modulus = 26;
            var ExpectedResult = 7;
            TestMethod(value, modulus, ExpectedResult);
        }

        private static void TestMethod(int value, int modulus, int? ExpectedResult)
        {
            ReflectionAssert.TestMethod(GetCalculateMethod(),
                            null, new object[] { value, modulus }, ExpectedResult);
        }

        [TestMethod]
        public void inv2mod12shouldBeNull()
        {
            var value = 2;
            var modulus = 12;
            int? ExpectedResult = null;
            TestMethod(value, modulus, ExpectedResult);
        }
    }
}
