using System;
using System.Collections.Generic;
using System.Linq;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Education.Web
{
 
    
    interface  ISkill
    {
    int ID { get; set; }
    [Required]
    [StringLength(500)]
    [Display(Name = "Skill Name")]
        string Name { get; set; }

    }
    
}