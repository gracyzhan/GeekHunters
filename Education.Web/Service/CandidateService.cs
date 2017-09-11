using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Education.Web.Service
{
    public class CandidateService
    {
        /// <summary>
        /// RegistCandidate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Boolean RegistCandidate(Candidate model)
        {
            Boolean opresult = false; 
            using (EducationContext dbContext = new EducationContext())
            {
                dbContext.Candidate.Add(model);
                int result = dbContext.SaveChanges();
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
            using (EducationContext db = new EducationContext())
            {
                var candidatesQuery = from s in db.Candidate
                                 select s;
                candidates = candidatesQuery.ToList<Candidate>();
            }
            return candidates;
        }

       

    }
}