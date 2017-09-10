using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Webdiyer.WebControls.Mvc;

namespace Education.Web
{
    public static class MemberManager
    {
        #region 判断是否存在指定用户名的用户
        /// <summary>
        /// 判断是否存在指定用户名的用户
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsHasMember(string name)
        {
            using (EducationContext edm = new EducationContext())
            {
                return edm.Member.Any(o => name.Equals(o.Account, StringComparison.OrdinalIgnoreCase));
            }
        } 
        #endregion

        #region 添加用户
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool AddMember(Member model)
        {
            using (EducationContext edm = new EducationContext())
            {
                edm.Member.Add(model);
                return edm.SaveChanges() > 0;
            }
        } 
        #endregion

        #region 根据用户名获取用户列表
        /// <summary>
        /// 根据用户名获取用户列表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static List<Member> GetMemberByName(string name)
        {
            using (EducationContext edm = new EducationContext())
            {
                return edm.Member.Where(o => name.Equals(o.Account, StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }  
        #endregion

        #region 查询
        /// <summary>
        /// 根据会员ID获取会员信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Member GetMemberById(Int64 id)
        {
            using (EducationContext edm = new EducationContext())
            {
                return edm.Member.FirstOrDefault(o => o.MemberId == id && o.IsDelete == false);
            }
        }

        public static bool IsHasNickname(Int64 uid, string nickname)
        {
            using (EducationContext edm = new EducationContext())
            {
                return edm.Member.Any(o => o.MemberId != uid && o.Nickname == nickname);
            }
        }

        public static PagedList<Member> GetMemberToPager(int pageIndex, int pageSize)
        {
            using (EducationContext edm = new EducationContext())
            {
                return edm.Member.OrderByDescending(o => o.MemberId).ToPagedList(pageIndex, pageSize);
            }
        } 
        #endregion

        #region 添加或更新会员详细信息
        /// <summary>
        /// 添加或更新会员详细信息
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public static bool UpdateMember(Member member)
        {
            if (member == null)
            {
                return false;
            }
            using (EducationContext edm = new EducationContext())
            {
                Member entity = edm.Member.FirstOrDefault(o => o.MemberId == member.MemberId);
                if (entity == null)
                {
                    return false;
                }
                if (string.IsNullOrWhiteSpace(member.Password) != false)
                {
                    entity.Password = member.Password;
                }
                entity.Nickname = member.Nickname;
                entity.Name = member.Name;
                entity.MyDescription = member.MyDescription;
                entity.Permissions = member.Permissions;
                entity.QqCode = member.QqCode;
                entity.Sex = member.Sex;
                entity.IsDelete = member.IsDelete;
                entity.Email = member.Email;
                entity.Blood = member.Blood;
                entity.Birthday = member.Birthday;
                entity.Blog = member.Blog;
                edm.Entry(entity).State = EntityState.Modified;
                return edm.SaveChanges() > 0;

            }
        } 
        #endregion
    }
}