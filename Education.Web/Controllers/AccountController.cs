using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Web
{
    public class AccountController : Controller
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            if (WebContext.IsLogin)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public int testSqlite()
        {
             
           // var list = MemberManager.GetMemberByName("admin");
            using (EducationContext edm = new EducationContext())
            {
                var test = edm.Skill.FirstOrDefault();
                Console.WriteLine(test.Name);
            }

            return 0; 
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Login(LoginEntity model)
        {
            if (ModelState.IsValid == false)
            {
                ViewBag.ErrorMessage = ModelState.FirstError();
                return View();
            }
            var list = MemberManager.GetMemberByName(model.Account);
            if (list == null || list.Count <= 0)
            {
                ViewBag.ErrorMessage = "您的用户名或密码不正确!";
                return View();
            }

            foreach (var member in list)
            {
                //if (PasswordHash.ValidatePassword(model.Password, member.Password))
                //{
                //    bool result = MemberLogin.Login(member);
                //    ViewBag.ErrorMessage = result == false ? "登录失败" : "";
                //    if (result == false)
                //    {
                //        return View();
                //    }
                //    return RedirectToAction("Index", "Home");
                //}
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ErrorMessage = "您的用户名或密码不正确!";
            return View();
        }

        public ActionResult Register()
        {
            if (WebContext.GetCurrentMember() != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Register(RegisterEntity model)
        {
            if (ModelState.IsValid == false)
            {
                ViewBag.ErrorMessage = ModelState.FirstError();
                return View();
            }
            if (MemberManager.IsHasMember(model.Account))
            {
                ViewBag.ErrorMessage = "用户名已存在。";
                return View();
            }
            Member member = new Member {Account = model.Account, Password = PasswordHash.CreateHash(model.Password)};
            if (MemberManager.AddMember(member))
            {
                MemberLogin.Login(member);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        
        public ActionResult Forgot()
        {
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Forgot(string model)
        {
            return View();
        }

        public ActionResult Logout()
        {
            MemberLogin.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}