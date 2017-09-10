using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Education.Web
{
    public class AuthorizeModule : IHttpModule, IRequiresSessionState
    {

        public void Init(HttpApplication context)
        {
            context.AcquireRequestState += context_AcquireRequestState;
        }

        public void Application_BeginRequest(Object sender, EventArgs e)
        {

        }
        public void context_AcquireRequestState(object sender, EventArgs e)
        {
            // 获取应用程序
            HttpApplication application = sender as HttpApplication;
            if (application == null)
            {
                HttpContext.Current.Response.Redirect("Login.aspx"); return;
            }

            HttpContext context = application.Context;
            string ext = Path.GetExtension(context.Server.MapPath(context.Request.Url.LocalPath));
            if (string.IsNullOrWhiteSpace(ext) == false)
            {
                if (ext.Equals(".html", StringComparison.OrdinalIgnoreCase))
                {
                    Member member = HttpContext.Current.Session["User"] as Member;
                    if (member == null)
                    {
                        string data = GetCurrentLogin();
                        if (string.IsNullOrWhiteSpace(data) == false)
                        {
                            int uid;
                            if (int.TryParse(data, out uid))
                            {
                                HttpContext.Current.Session["User"] = MemberManager.GetMemberById(uid);
                            }
                        }
                    }
                }
            }

        }
        public void Dispose() { }

        private string GetCurrentLogin()
        {

            HttpCookie cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null || string.IsNullOrWhiteSpace(cookie.Value))
            {
                return string.Empty;
            }
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
            if (ticket != null && string.IsNullOrWhiteSpace(ticket.UserData)==false)
            {
                return ticket.UserData;
            }
            return string.Empty;
        }
    }
}