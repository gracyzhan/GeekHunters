using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Web
{
    [Table("Articles")]
    public class Article
    {
        public Article()
        {
            CreateTime = DateTime.Now;
            Author = "佚名";
            Source = "互联网";
        }
        [Key]
        [Display(Name = "文章ID")]
        public Int64 ArticleId { set; get; }
        [Display(Name = "添加人")]
        public Int64 MemberId { set; get; }
        [Display(Name = "文章标题")]
        [Required(ErrorMessage = "文章标题必须填写")]
        [StringLength(100,ErrorMessage = "文章标题必须小于100个字",MinimumLength = 2)]
        public string Title { set; get; }
        [Display(Name = "副标题")]
        [StringLength(100, ErrorMessage = "文章副标题必须小于100个字", MinimumLength = 2)]
        public string SubTitle { set; get; }
        [Display(Name = "作者")]
        [StringLength(10, ErrorMessage = "作者必须小于10个字", MinimumLength = 2)]
        public string Author { set; get; }
        [Display(Name = "文章来源")]
        [StringLength(100, ErrorMessage = "文章来源必须小于100个字", MinimumLength = 2)]
        public string Source { set; get; }
        [Display(Name = "摘要")]
        [StringLength(200, ErrorMessage = "文章摘要必须小于100个字", MinimumLength = 2)]
        public string Summary { set; get; }
        [Display(Name = "文章正文")]
        [Required(ErrorMessage = "文章内容不能为空")]
        [AllowHtml]
        public string Content { set; get; }
        [Display(Name = "添加时间")]
        public DateTime CreateTime { set; get; }
    }
}