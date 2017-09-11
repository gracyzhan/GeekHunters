using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GracyDemoSkills.Web.Service
{
    public class SkillService
    {
        public static IEnumerable<Skill> QueryAllSkills()
        {
            IEnumerable<Skill> skiils = new List<Skill>();
            using (RecruitContext db = new RecruitContext())
            {
                var skiilQuery = from s in db.Skill
                                 select s;
                skiils = skiilQuery.ToList<Skill>();
            }
            return skiils;
        }

         
    }
}