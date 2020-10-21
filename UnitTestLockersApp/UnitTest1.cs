using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LokerTest;

namespace UnitTestLockersApp
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLoginAdmin()
        {
            Menu menu = new Menu();
            var result = menu.login("admin", "admin");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestLoginNonAdmin()
        {
            Menu menu = new Menu();
            var result = menu.login("user", "user");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestInputNumber()
        {
            Menu menu = new Menu();
            int Index = 0;
            string var = "12";
            var result = menu.InputIntMode(var,Index);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestInputNotNumber()
        {
            Menu menu = new Menu();
            int Index = 0;
            string var = "abc";
            var result = menu.InputIntMode(var, Index);
            Assert.IsFalse(result);
        }
    }
}
