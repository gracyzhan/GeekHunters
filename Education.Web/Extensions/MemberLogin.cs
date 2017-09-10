using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Education.Web
{
    public static class MemberLogin
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Login(Member model)
        {
            string id = model.MemberId.ToString(CultureInfo.InvariantCulture);
            HttpContext.Current.Session["User"] = model;
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, "token", DateTime.Now, DateTime.Now.AddMinutes(30), true, id, "/");
            FormsAuthentication.SignOut();
            FormsAuthentication.SetAuthCookie(id, false);
            FormsAuthentication.RedirectFromLoginPage(id, true);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket))
            {
                HttpOnly = true
            };
            HttpContext.Current.Response.Cookies.Add(cookie);
            return true;
        }

        public static void Logout()
        {
            HttpContext.Current.Session["User"] = null;
            HttpContext.Current.Session.Abandon();
            FormsAuthentication.SignOut();
        }
    }
}