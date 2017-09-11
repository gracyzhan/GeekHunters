using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Education.Web.Service
{
    public class CandidateSkillSetService
    {
        public static IEnumerable<CandidateSkillSet> QueryCandidateViaSkills(string skills)
        {
            IEnumerable<CandidateSkillSet> candidates = new List<CandidateSkillSet>();
            using (EducationContext db = new EducationContext())
            {
                var candidatesQuery = from s in db.CandidateSkillSet
                                      select s;
                candidates = candidatesQuery.ToList<CandidateSkillSet>();
            }
            return candidates;
        }

         
    }
}