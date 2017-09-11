using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace GracyDemoSkills.Web
{
    [Table("Skill")]
    public class Skill : ISkill
    {
        public Int64 Id { set; get; }
        public String Name { set; get; }
    }
}