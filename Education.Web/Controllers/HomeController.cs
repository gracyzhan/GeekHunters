using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Web
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? page)
        {
            page = page == null || page <= 0 ? 1 : page;
            var list = ArticleManager.GetArticleListToPager((int)page, 1);

            return View(list);
        }


        #region 个人信息
        [AuthorizeFilter]
        public ActionResult AboutMe()
        {
            var member = WebContext.GetCurrentMember();
            if (member == null)
            {
                MemberLogin.Logout();
                return RedirectToAction("Login", "Account");
            }
            return View(member);
        }
        [AuthorizeFilter]
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult AboutMe(Member model)
        {
            if (ModelState.IsValid == false)
            {
                ViewBag.ErrorMessage = ModelState.FirstError();
                return View();
            }
            Member member = WebContext.GetCurrentMember();
            if (member == null)
            {
                MemberLogin.Logout();
                return RedirectToAction("Login", "Account");
            }
            if (string.IsNullOrWhiteSpace(model.Nickname) == false && MemberManager.IsHasNickname(member.MemberId, model.Nickname))
            {
                model.Password = "";
                ViewBag.ErrorMessage = "您的昵称重复啦！";
                return View(model);
            }
            if (string.IsNullOrWhiteSpace(model.Password) == false && model.Password != "0000000000000000")
            {
                model.Password = PasswordHash.CreateHash(model.Password);
            }
            model.Permissions = member.Permissions;
            model.IsDelete = member.IsDelete;
            model.MemberId = member.MemberId;
            model.Account = member.Account;
            model.CreateTime = member.CreateTime;

            bool result = MemberManager.UpdateMember(model);
            if (result == false)
            {
                ViewBag.ErrorMessage = "修改个人信息失败！";

            }
            else
            {
                ViewBag.Message = "修改成功！";
                WebContext.SetCurrentSession(model);
            }

            return View(model);
        } 
        #endregion

        #region 文章管理
        [AuthorizeFilter]
        public ActionResult AddArticle(int? id)
        {
             Article article = new Article();
            Member member = WebContext.GetCurrentMember();
            if (member == null || member.Permissions <= 0)
            {
                ViewBag.PermissionsErrorMessage = "您没有发布文章的权限！";
                return View(article);
            }
            if (id != null && id > 0)
            {
                article = ArticleManager.GetArticleById((int)id);

            }
            return View(article);
        }
        [HttpPost, AuthorizeFilter]
        public ActionResult AddArticle(Article model)
        {
            Member member = WebContext.GetCurrentMember();
            if (member == null || member.Permissions <= 0)
            {
                ViewBag.ErrorMessage = "您没有发布文章的权限！";
                return View(model);
            }
            if (ModelState.IsValid == false)
            {
                ViewBag.ErrorMessage = ModelState.FirstError();
                return View(model);
            }
            model.MemberId = member.MemberId;
            bool result = ArticleManager.AddOrUpdateArticle(model);
            if (result == false)
            {
                ViewBag.ErrorMessage = "保存文章失败！";
            }
            else
            {
                ViewBag.Message = "保存成功！";
            }
            return View();
        }
        [HttpPost, AuthorizeFilter]
        public ActionResult DelArticle(int? id)
        {
            Member member = WebContext.GetCurrentMember();
            if (member == null || member.Permissions <= 0)
            {
                ViewBag.ErrorMessage = "您没有删除文章的权限！";
                return View();
            }
            if (id == null || id <= 0)
            {
                ViewBag.ErrorMessage = "文章不存在！";
                return View();
            }
            bool result = ArticleManager.DelArticale((int) id);
            if (result == false)
            {
                ViewBag.ErrorMessage = "删除失败！";
            }
            else
            {
                ViewBag.ErrorMessage = "删除成功！";
            }
            return View();
        }
        public ActionResult Article(int? id)
        {
            Article article = new Article();
            if (id != null && id > 0)
            {
                article = ArticleManager.GetArticleById((int)id);
            }
            return View(article);
        }
        #endregion

    }
}