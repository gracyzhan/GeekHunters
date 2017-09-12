using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GracyDemoSkills.Web.Service
{
    public class CandidateService : IGeneralService
    {
        /// <summary>
        /// RegistCandidate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Boolean RegistCandidate(ICandidateDetail model)
        {
            Boolean opresult = false; 
            using (RecruitContext dbContext = new RecruitContext())
            {
                dbContext.Candidate.Add(model.candidate);
                dbContext.SaveChanges();
                //insert the skill part
                if (model.candidate.Id > 0)
                { 
                List<CandidateSkillSet> CandidateSkillSets = new List<CandidateSkillSet>();
                CandidateSkillSet candidateSkillSet;
                foreach (Int64 skillId in model.SkillIds)
                {
                    candidateSkillSet = new CandidateSkillSet();
                    candidateSkillSet.SkillId = skillId;
                    candidateSkillSet.CandidateId = model.candidate.Id ;
                    CandidateSkillSets.Add( 
                        candidateSkillSet
                         );
                }
                dbContext.CandidateSkillSet.AddRange(CandidateSkillSets);
                dbContext.SaveChanges();
                }
                {
                    //throw Exception ;
                }
                opresult = true;
            }
            return opresult;
        }

        /// <summary>
        /// QueryAllCandidate
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Candidate> QueryAllCandidate()
        {
            IEnumerable<Candidate> candidates = new List<Candidate>();
            using (RecruitContext db = new RecruitContext())
            {
                var candidatesQuery = from s in db.Candidate
                                 select s;
                candidates = candidatesQuery.ToList<Candidate>();
            }
            return candidates;
        }

       

    }
}