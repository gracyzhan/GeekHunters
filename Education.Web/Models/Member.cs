using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Education.Web
{
    [Table("Member")]
    public class Member
    {
        public Member()
        {
            CreateTime = DateTime.Now;
            Permissions = 0;
            IsDelete = false;
        }
        [Key]
        [Display(Name = "会员ID")]
        [Required(ErrorMessage = "会员Id为必选项")]
        public Int64 MemberId { set; get; }
        [Display(Name = "会员账号")]
        [Required(ErrorMessage = "会员账号必须填写")]
        [StringLength(20,ErrorMessage = "会员账号必须大于3个字符小于20个字符",MinimumLength = 3)]
        public string Account { set; get; }
        [Display(Name = "密码"),Required(ErrorMessage = "密码不能为空")]
        [StringLength(200,ErrorMessage = "密码必须大于6位小于200位",MinimumLength = 6)]
        public string Password { set; get; }
        [Display(Name = "会员昵称")]
        [StringLength(20, ErrorMessage = "会员昵称必须大于3个字符小于20个字符", MinimumLength = 3)]
        public string Nickname { set; get; }
        [Display(Name = "真实姓名")]
        [StringLength(20, ErrorMessage = "真实姓名必须大于2个字符小于20个字符", MinimumLength = 2)]
        public string Name { set; get; }
        [Display(Name = "性别")]
        public int? Sex { set; get; }
        [Display(Name = "生日")]
        public DateTime? Birthday { set; get; }
        [Display(Name = "血型")]
        [MaxLength(10,ErrorMessage = "血型填写不正确")]
        public string Blood { set; get; }
        [Display(Name = "简介")]
        [StringLength(100,ErrorMessage = "不要超过100个字",MinimumLength = 0)]
        public string MyDescription { set; get; }
        [Display(Name = "邮箱")]
        [MaxLength(120,ErrorMessage = "邮箱不能超过120字符")]
        public string Email { set; get; }
        [Display(Name = "博客地址")]
        [MaxLength(100,ErrorMessage = "博客地址不能超过100字符")]
        public string Blog { set; get; }
        [Display(Name = "QQ")]
        [MaxLength(20,ErrorMessage = "QQ长度不能超过20字符")]
        public string QqCode { set; get; }
        /// <summary>
        /// 权限，0 普通/1发文章/2管理员/3超级管理员
        /// </summary>
        [Display(Name = "权限")]
        public int Permissions { set; get; }
        /// <summary>
        /// 是否删除
        /// </summary>
        [Display(Name = "是否删除")]
        public bool IsDelete { set; get; }
        public DateTime CreateTime { set; get; }
    }
}