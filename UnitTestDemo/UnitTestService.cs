using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GracyDemoSkills.Web.Controllers;
using GracyDemoSkills.Web;
using GracyDemoSkills.Web.Service;
namespace UnitTestDemo
{
    [TestClass]
    public class UnitTestService
    {
        [TestMethod]
        public void TestRegistCandidate()
        {
            Candidate model = new Candidate();
            CandidateDetail detailModel = new CandidateDetail();
            model.FirstName = "unitTestFirst";
            model.LastName = "unitTestLast";
            detailModel.candidate = model;
            List<Int64> skillIds = new List<Int64>();
            skillIds.Add(1);
            detailModel.SkillIds = skillIds;
            var result  =  CandidateService.RegistCandidate(detailModel);
            Assert.IsTrue(result);
        }
    }
}
