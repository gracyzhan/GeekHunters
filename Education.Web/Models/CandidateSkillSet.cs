using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Education.Web
{
    [Table("CandidateSkillSet")]
    public class CandidateSkillSet : ICandidateSkillSet
    {
        public Int64 CandidateId
        {
            get; set;
        }

        [Key]
        public Int64 Id
        {
            get; set;
        }

        public Int64 SkillId
        {
            get; set;
        }

        
    }
}