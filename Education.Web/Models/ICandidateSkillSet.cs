using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Education.Web
{
    interface  ICandidateSkillSet
    {
        Int64 Id { get; set; }
        Int64 CandidateId { get; set; }
        Int64 SkillId { get; set; }
    }
}