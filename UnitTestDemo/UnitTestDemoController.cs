using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using GracyDemoSkills.Web.Controllers;
namespace UnitTestDemo
{
    [TestClass]
    public class UnitTestDemoController
    {
        [TestMethod]
        public void TestGetAllSkill() 
        {
            DemoController demoCtrl = new DemoController();
            var skills = demoCtrl.GetAllSkill();
            Assert.IsFalse(string.IsNullOrEmpty(skills));
        }


        
    }
}
