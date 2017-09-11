using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Education.Web.Service
{
    public class CandidateSkillSetDetailService
    {
        public static IEnumerable<CandidateSkillSetDetail> QueryCandidateDetailViaSkills(string skills)
        {
            IEnumerable<CandidateSkillSetDetail> candidates = new List<CandidateSkillSetDetail>();
            using (EducationContext db = new EducationContext())
            {
                string sql = "select CandidateSkillSet.ID, CandidateSkillSet.CandidateId, CandidateSkillSet.SkillId , a.name as SkillName ,  b.FirstName  as CandidateFirstName , b.LastName   as CandidateLastName from CandidateSkillSet inner join Skill a on CandidateSkillSet.SkillId = a.Id inner join Candidate b on CandidateSkillSet.CandidateId = b.Id ";
                var candidatesQuery = db.Database.SqlQuery<CandidateSkillSetDetail>(sql);
                candidates = candidatesQuery.ToList<CandidateSkillSetDetail>();
            }
            return candidates;
        }

    }
}