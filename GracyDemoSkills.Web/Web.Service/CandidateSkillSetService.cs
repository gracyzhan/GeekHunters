﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GracyDemoSkills.Web.Service
{
    public class CandidateSkillSetService : IGeneralService
    {
        public static IEnumerable<CandidateSkillSet> QueryCandidateViaSkills(string skills)
        {
            IEnumerable<CandidateSkillSet> candidates = new List<CandidateSkillSet>();
            using (RecruitContext db = new RecruitContext())
            {
                var candidatesQuery = from s in db.CandidateSkillSet
                                      select s;
                candidates = candidatesQuery.ToList<CandidateSkillSet>();
            }
            return candidates;
        }

         
    }
}