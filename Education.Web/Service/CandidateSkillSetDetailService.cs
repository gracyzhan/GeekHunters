using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Education.Web.Service
{
    public class CandidateSkillSetDetailService
    {
        public static IEnumerable<CandidateSkillSetDetail> QueryCandidateDetailViaSkills(string[] skillIds)
        {
            IEnumerable<CandidateSkillSetDetail> candidates = new List<CandidateSkillSetDetail>();
            using (EducationContext db = new EducationContext())
            {
                string sql = "select CandidateSkillSet.ID, CandidateSkillSet.CandidateId, CandidateSkillSet.SkillId , a.name as SkillName ,  b.FirstName  as CandidateFirstName , b.LastName "
                   + " as CandidateLastName from CandidateSkillSet inner join Skill a on CandidateSkillSet.SkillId = a.Id inner join Candidate b on CandidateSkillSet.CandidateId = b.Id ";
                if (skillIds != null && skillIds.Length > 0)
                {
                    sql += " where CandidateSkillSet.SkillId in (" + string.Join (",",skillIds) + ") ";
                }
                 
                var candidatesQuery = db.Database.SqlQuery<CandidateSkillSetDetail>(sql);
                candidates = candidatesQuery.ToList<CandidateSkillSetDetail>();
                var distinctCandidatesList = candidates.Select(c => new { c.CandidateId, c.CandidateLastName, c.CandidateFirstName }).Distinct();
                var returnCandidateList = distinctCandidatesList.Select(c => new CandidateSkillSetDetail { CandidateId= c.CandidateId,CandidateFirstName = c.CandidateFirstName, CandidateLastName= c.CandidateLastName, SkillName = string.Join(", ", candidates.Where(s => s.CandidateId == c.CandidateId).Select(s => s.SkillName).ToList<string>()) });
                return returnCandidateList.ToList<CandidateSkillSetDetail>();
            }
        }

    }
}