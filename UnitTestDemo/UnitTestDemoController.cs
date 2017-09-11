﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GracyDemoSkills.Web;
using GracyDemoSkills.Web.Controllers;
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
            var skills = demoController.GetAllSkill();
            Assert.IsFalse(string.IsNullOrEmpty(skills));
        }
    }
}
