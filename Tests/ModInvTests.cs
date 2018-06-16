using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MGN.ModInv.Tests
{
    [TestClass]
    public class ModInvTests
    {
        [TestMethod]
        public void MGN_ModInv_dllShouldExist()
        {
            ReflectionAssert.AssemblyExists("MGN.ModInv.dll");
        }
    }
}
