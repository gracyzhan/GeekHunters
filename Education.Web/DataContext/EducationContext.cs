using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Education.Web
{
    public class EducationContext :DbContext
    {
        public EducationContext() : base("EducationStrings") { Database.SetInitializer<EducationContext>(null); }
        /// <summary>
        /// 访问会员表
        /// </summary>
        public DbSet<Member> Member { set; get; }
        /// <summary>
        /// 文章表
        /// </summary>
        public DbSet<Article> Article { set; get; }
        /// <summary>
        /// 公告表
        /// </summary>
        public DbSet<Announcement> Announcement { set; get; } 
    }
}