using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GracyDemoSkills.Web
{
    public class EducationContext :DbContext
    {
        public EducationContext() : base("EducationStrings") { Database.SetInitializer<EducationContext>(null); }

        public DbSet<Skill> Skill { set; get; }
        public DbSet<Candidate> Candidate { set; get; }
        public DbSet<CandidateSkillSet> CandidateSkillSet { set; get; }


    }
}