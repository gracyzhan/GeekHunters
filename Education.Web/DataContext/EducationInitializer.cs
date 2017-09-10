using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Education.Web
{
    public class EducationInitializer : DropCreateDatabaseIfModelChanges<EducationContext>  
    {
        protected override void Seed(EducationContext context)
        {
            context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX IX_Member_Account ON Member(Account)");
            var member = new Member
            {
                Account = "admin",
                Password = PasswordHash.CreateHash("123456."),
                Email = "lifei6671@163.com",
                Birthday = DateTime.Parse("1990-06-06 08:30:20"),
                Blog = "http://www.gov.cn",
                Blood = "A",
                MyDescription = "我思故我在!",
                Name = "大卫",
                Nickname = "大威德",
                Permissions = 3
            };
            context.Member.Add(member);
        }
    }
}