using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Property_Management.Models;
using System.Collections;

namespace Property_Management.Controllers
{
    public class NewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [AllowAnonymous]
        public ActionResult NewsList(int? id)
        {
            if (id == null)
            { 
            return View(db.News.OrderByDescending(x => x.CreatedOn).ToList());
            }

            IEnumerable news = db.News.Where(x=> x.NewsId == id).ToList();
            if (news ==null)
            {
                //Redirect to no such page found error page
                return HttpNotFound();
            }
            return View(news);

        }

        public ActionResult FeaturedNews()
        {
            var featured = db.News.Where(x => x.IsFeatured == true).ToList();
            return View(featured);
        }
        // GET: News
        public ActionResult Index()
        {
           
            return View(db.News.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(News news)
        {
            if (ModelState.IsValid)
            {

                string previewString = String.Format("{0}...", news.Content.ToString().Substring(0, 140));

                news.CreatedOn = DateTime.Now;
                news.Preview = previewString;
                db.News.Add(news);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(news);
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //or redirect to no such page 
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditNewsViewModel news)
        {
            if (ModelState.IsValid)
            {
                var oldNews = db.News.Find(news.NewsId);

                oldNews.Title = news.Title;
                oldNews.Content = news.Content;
                oldNews.IsFeatured = news.IsFeatured;
                oldNews.Preview = string.Format("{0}...", news.Content.ToString().Substring(0, 1));

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = db.News.Find(id);
            db.News.Remove(news);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}