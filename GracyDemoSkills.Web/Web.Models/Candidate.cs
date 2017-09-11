using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GracyDemoSkills.Web
{
    [Table("Candidate")]
    public class Candidate   : ICandidate
    {
         
        public string FirstName
        {
            get;set;
        }
         
        [Key]
        public Int64 Id
        {
            get; set;
        }
         
        public string LastName
        {
            get; set;
        }
    }
}