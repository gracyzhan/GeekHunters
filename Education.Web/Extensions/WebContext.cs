using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Education.Web
{
    public static class WebContext
    {
        public static bool IsLogin
        {
            get { return HttpContext.Current.Session["User"] != null; }
        }

        public static void SetCurrentSession(Member model)
        {
            HttpContext.Current.Session["User"] = model;
        }
        /// <summary>
        /// 获取当前登录用户
        /// </summary>
        /// <returns></returns>
        public static Member GetCurrentMember()
        {

            Member member = HttpContext.Current.Session["User"] as Member;
            if (member == null)
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (cookie == null || string.IsNullOrWhiteSpace(cookie.Value))
                {
                    return null;
                }
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
                if (ticket == null || string.IsNullOrWhiteSpace(ticket.UserData))
                {
                    return null;
                }
                int uid;
                if (int.TryParse(ticket.UserData, out uid))
                {
                    using (EducationContext edm = new EducationContext())
                    {
                        member = edm.Member.FirstOrDefault(o =>o.MemberId == uid);
                    }
                    HttpContext.Current.Session["User"] = member;
                }
            }
            return member;
        }
        
    }
}