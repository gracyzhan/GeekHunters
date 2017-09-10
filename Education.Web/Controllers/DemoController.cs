using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

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
            using (EducationContext db = new EducationContext())
            {
                var skiilQuery = from s in db.Skill
                             select s;
                skiils = skiilQuery.ToList<Skill>();
            }

            var json = new JavaScriptSerializer().Serialize(skiils);

            return json;
        }

        // GET: api/Skill
        public String GetAllSkillName()
        {
            IEnumerable<Skill> skiils = new List<Skill>();
            using (EducationContext db = new EducationContext())
            {
                var skiilQuery = from s in db.Skill
                                 select s;
                skiils = skiilQuery.ToList<Skill>();
            }

            var nameStr = skiils.Select(s=> s.Name).ToArray();
            return string.Join(",", nameStr);
        }

        // GET: api/Skill
        public IEnumerable<CandidateSkillSet> QueryCandidatesAndSkill(String skillSets)
        {
            IEnumerable<CandidateSkillSet> skiils = new List<CandidateSkillSet>();
            using (EducationContext db = new EducationContext())
            {
                var skiilQuery = from s in db.CandidateSkillSet
                                 select s;
                skiils = skiilQuery.ToList<CandidateSkillSet>();
            }

            return skiils;
        }

        // POST: api/Skill
        public void RegistCandidate(Candidate model)
        {
            using (EducationContext db = new EducationContext())
            {

                db.Candidate.Add(model);
                db.SaveChanges();
            }

        }


    }
}