using System;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Education.Web;
namespace UnitTestDemo
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Education.Web.AccountController ac = new AccountController();
            var t = ac.testSqlite();
        }

         
    }
}
