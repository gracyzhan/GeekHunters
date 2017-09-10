using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Education.Web
{
    interface  ICandidateSkillSet
    {
        int ID { get; set; }
        int CandidateID { get; set; }
        int SkillID { get; set; }
    }
}