using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Web
{
    public class MemberController : Controller
    {
        [HttpGet, AuthorizeFilter]
        public ActionResult Index(int? page)
        {
            Member member = WebContext.GetCurrentMember();
            if (member == null || member.Permissions!=3)
            {
                ViewBag.PermissionsErrorMessage = "您没有发布文章的权限！";
                return View();
            }
            page = page == null || page <= 0 ? 1 : page;
            var list = MemberManager.GetMemberToPager((int) page, 10);
            return View(list);
        }
        [HttpPost,AuthorizeFilter]
        public ActionResult Index(int?[] ids,int? page)
        {
            return View();
        }
        [AuthorizeFilter]
        public ActionResult Edit(int? mid)
        {
            Member member = WebContext.GetCurrentMember();
            if (member == null || member.Permissions != 3)
            {
                ViewBag.PermissionsErrorMessage = "您没有发布文章的权限！";
                return View();
            }
            
            Member entity = new Member();
            if (mid > 0)
            {
                if (member.MemberId == (int)mid)
                {
                    return RedirectToAction("AboutMe", "Home");
                }
                entity = MemberManager.GetMemberById((int)mid);
            }
            return View(entity);
        }
        [HttpPost,AuthorizeFilter]
        public ActionResult Edit(Member model)
        {
            if (ModelState.IsValid == false)
            {
                ViewBag.ErrorMessage = ModelState.FirstError();
                return View();
            }
            if (model.MemberId <= 0)
            {
                ViewBag.ErrorMessage = "不存在该会员！";
                return View(model);
            }
            Member member = WebContext.GetCurrentMember();
            if (member == null)
            {
                MemberLogin.Logout();
                return RedirectToAction("Login", "Account");
            }
            
            if (string.IsNullOrWhiteSpace(model.Nickname) == false && MemberManager.IsHasNickname(model.MemberId, model.Nickname))
            {
                model.Password = "";
                ViewBag.ErrorMessage = "您的昵称重复啦！";
                return View(model);
            }
            if (string.IsNullOrWhiteSpace(model.Password) == false && model.Password != "0000000000000000")
            {
                model.Password = PasswordHash.CreateHash(model.Password);
            }
            bool result = MemberManager.UpdateMember(model);
            if (result == false)
            {
                ViewBag.ErrorMessage = "修改失败！";

            }
            else
            {
                ViewBag.Message = "修改成功！";
            }

            return View(model);
        }
    }
}