using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GracyDemoSkills.Web
{
    interface  ICandidateSkillSet
    {
        Int64 Id { get; set; }
        Int64 CandidateId { get; set; }
        Int64 SkillId { get; set; }
    }
}