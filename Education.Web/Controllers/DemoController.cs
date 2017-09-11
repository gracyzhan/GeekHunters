using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Education.Web.Service;
namespace Education.Web.Controllers
{
    public class DemoController : Controller
    {

        public ActionResult Demo()
        {
            ViewBag.Message = "Demo Page.";

            return View();
        }

        // GET: api/Skill
        public String GetAllSkill()
        {
            IEnumerable<Skill> skiils = new List<Skill>();
            //using (EducationContext db = new EducationContext())
            //{
            //    var skiilQuery = from s in db.Skill
            //                 select s;
            //    skiils = skiilQuery.ToList<Skill>();
            //}
            skiils = SkillService.QueryAllSkills();
            var json = new JavaScriptSerializer().Serialize(skiils);
            return json;
        }

        // GET: api/Skill
        public String QueryCandidates()
        {
            IEnumerable<Candidate> Candidates = new List<Candidate>();
            Candidates = CandidateService.QueryAllCandidate();
            var json = new JavaScriptSerializer().Serialize(Candidates);
            return json;
        }


        // GET: api/Skill
        public String QueryCandidatesAndSkill(String skillSets)
        {
            IEnumerable<CandidateSkillSetDetail> Candidates = new List<CandidateSkillSetDetail>();
            Candidates = CandidateSkillSetDetailService.QueryCandidateDetailViaSkills("");
            var json = new JavaScriptSerializer().Serialize(Candidates);
            return json;
        }

        // POST: api/Skill
        public void RegistCandidate(CandidateDetail model)
        {
           Boolean result =  CandidateService.RegistCandidate(model);
        }


    }
}