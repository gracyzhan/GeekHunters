using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GracyDemoSkills.Web
{
    interface ICandidate
    {
        Int64 Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        string LastName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        string FirstName { get; set; }
        //[Display(Name = "Full Name")]
        //string FullName
        //{
        //    get;

        //}
    }
}