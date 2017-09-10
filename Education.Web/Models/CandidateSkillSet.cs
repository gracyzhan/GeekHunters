using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Education.Web
{
    public class CandidateSkillSet : ICandidateSkillSet
    {
        public int CandidateID
        {
            get; set;
        }

        public int ID
        {
            get; set;
        }

        public int SkillID
        {
            get; set;
        }

        public string SkillName
        {
            get;
        }

        public string CandidateName
        {
            get;
        }
    }
}