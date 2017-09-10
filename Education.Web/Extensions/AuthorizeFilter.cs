using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Education.Web
{
    /// <summary>
    /// 登陆状态拦截器,如果当前用户未登录则跳转到登陆页面
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizeFilterAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (HttpContext.Current.Session["User"] == null)
            {
                return string.IsNullOrWhiteSpace(GetCurrentLogin()) == false;
            }
            return true;
        }
        private string GetCurrentLogin()
        {

            HttpCookie cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null || string.IsNullOrWhiteSpace(cookie.Value))
            {
                return string.Empty;
            }
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
            if (ticket != null && string.IsNullOrWhiteSpace(ticket.UserData) == false)
            {
                return ticket.UserData;
            }
            return string.Empty;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext context)
        {
            HttpContext.Current.Response.Redirect("/login.html");
            HttpContext.Current.Response.SuppressContent = false;
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }
}