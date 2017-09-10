using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Education.Web
{
    public class LoginEntity
    {
        public LoginEntity()
        {
            Remember = false;
            MemberId = 0;
        }
        public int MemberId { set; get; }
        [Display(Name = "登录名")]
        [Required(ErrorMessage = "登录名不能为空")]
        public string Account { set; get; }
        [Display(Name = "密码")]
        [Required(ErrorMessage = "密码不能为空")]
        public string Password { set; get; }

        public bool Remember { set; get; }
    }
}