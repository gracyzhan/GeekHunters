using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Education.Web
{
    public class RegisterEntity
    {
        [Display(Name = "用户名")]
        [Required(ErrorMessage = "用户名不能为空")]
        [StringLength(20,ErrorMessage = "用户名必须大于3个小于20个字符",MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9_]*$|^[a-z]([a-z0-9]*[-_]?[a-z0-9]+)*@([a-z0-9]*[-_]?[a-z0-9]+)+[\.][a-z]{2,3}([\.][a-z]{2})?$", ErrorMessage = "用户名必须是以英文字母开头")]
        public string Account { set; get; }
        [Display(Name = "密码")]
        [Required(ErrorMessage = "密码不能为空")]
        [StringLength(20, ErrorMessage = "密码必须大于6个小于20个字符", MinimumLength = 6)]
        public string Password { set; get; }
        [Display(Name = "确认密码")]
        [Required(ErrorMessage = "确认密码不能为空")]
        [Compare("Password",ErrorMessage = "确认密码和原密码不一致")]
        public string ConfirmPassword { set; get; }
        
    }
}