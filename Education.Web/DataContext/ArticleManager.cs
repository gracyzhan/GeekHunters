using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Webdiyer.WebControls.Mvc;

namespace Education.Web
{
    public class ArticleManager
    {
        public static PagedList<Article> GetArticleListToPager(int pageIndex, int pageSize)
        {
            using (EducationContext edm = new EducationContext())
            {
                return edm.Article.OrderByDescending(o => o.ArticleId).ToPagedList(pageIndex, pageSize);
            }
        }

        public static bool DelArticale(int id)
        {
            using (EducationContext edm = new EducationContext())
            {
                Article entity = edm.Article.FirstOrDefault(o => o.ArticleId == id);
                if (entity != null)
                {
                    edm.Entry(entity).State = EntityState.Deleted;
                    return edm.SaveChanges() > 0;
                }
            }
            return false;
        }
        public static Article GetArticleById(int aid)
        {
            using (EducationContext edm = new EducationContext())
            {
                return edm.Article.FirstOrDefault(o => o.ArticleId == aid);
            }
        }

        public static bool AddOrUpdateArticle(Article model)
        {
            using (EducationContext edm = new EducationContext())
            {
                if (model.ArticleId > 0)
                {
                    edm.Article.Attach(model);
                    edm.Entry(model).State = EntityState.Modified;
                    return edm.SaveChanges() > 0;
                }
                else
                {
                    edm.Article.Add(model);
                    return edm.SaveChanges() > 0;
                }
            }
        }
    }
}