﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YayOrNay.Models;
using PagedList;



namespace YayOrNay.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        YayOrNayDb _db = new YayOrNayDb();



        public ActionResult Autocomplete (string term)
        {
            var model =
                _db.Movies
                .Where(r => r.Title.StartsWith(term))
                .Take(10)
                .Select(r => new
                {
                    label = r.Title
                });

            return Json(model, JsonRequestBehavior.AllowGet);

        }

        [OutputCache(Duration =60)]
        public ActionResult Index(string searchTerm = null, int page = 1)
        {

            //var model =
            //    from r in _db.Movies
            //    orderby r.Reviews.Average(review => review.Rating) descending
            //    select new MovieListViewModel
            //    {
            //       Id = r.Id,
            //        Title = r.Title,
            //        Genre = r.Genre,
            //        Certificate = r.Certificate,
            //        CountOfReviews = r.Reviews.Count()
            //    };

            var model =
                 _db.Movies
                 .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                 .Where(r => searchTerm == null || r.Title.StartsWith(searchTerm))

                 .Select(r => new MovieListViewModel
                         {
                     
                             Id = r.Id,
                     //Files = r.Files,
                            Description = r.Description,
                            Title = r.Title,
                             Genre = r.Genre,
                             Certificate = r.Certificate,
                             ReleaseDate = r.ReleaseDate,
                             CountOfReviews = r.Reviews.Count()
                         }).ToPagedList(page, 3);




            if (Request.IsAjaxRequest())
            {
                return PartialView("_Movies", model);
            }
          

            return View(model);
        }




        public ActionResult About()
        {
            var model = new AboutModel();
            model.Name = "Keith";
            model.Location = "Dublin, Ireland";

            return View(model);

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Would you like to contact me?";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}