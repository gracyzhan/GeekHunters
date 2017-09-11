using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Education.Web 
{
    public class CandidateSkillSetDetail  
    {

        public Int64 CandidateId
        {
            get; set;
        }

        public Int64 Id
        {
            get; set;
        }

        public Int64 SkillId
        {
            get; set;
        }


        public string SkillName
        {
            get; set;

        }

        public string CandidateFirstName
        {
            get; set;
        }

        public string CandidateLastName
        {
            get; set;
        }
    }
}