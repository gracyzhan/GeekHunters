using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GracyDemoSkills.Web 
{
    public interface ICandidateDetail  
    {
          Candidate candidate { get; set; }
          IEnumerable<Int64> SkillIds { set; get; }
          IEnumerable<Int64> SkillNames { set; get; }

    }
}