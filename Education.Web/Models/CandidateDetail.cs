using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Education.Web 
{
    public class CandidateDetail  
    {
        public Candidate candidate { get; set; }
        public IEnumerable<Int64> SkillIds { set; get; }
        public IEnumerable<Int64> SkillNames { set; get; }

    }
}