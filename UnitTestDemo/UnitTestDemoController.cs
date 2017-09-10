using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Education.Web;
using Education.Web.Controllers;
using System.Collections;
using System.Collections.Generic;

namespace UnitTestDemo
{
    [TestClass]
    public class UnitTestDemoController
    {
        [TestMethod]
        public void TestGetAllSkill() 
        {
            DemoController demoController = new  DemoController();
            var skills = demoController.GetAllSkill().ToList<Skill>();
            Assert.AreNotEqual(0, skills.Count);
        }
    }
}
