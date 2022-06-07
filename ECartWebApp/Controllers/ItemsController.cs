using ECartWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECartWebApp.Controllers
{
    public class ItemsController : Controller
    {
        private ApplicationDbContext _dbContext;
        
        public ItemsController()
        {
            _dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        // GET: Items
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit()
        {
            ViewBag.categories = new SelectList(_dbContext.Categories.ToList(), "ID", "CategoryName");

            return View();
        }
    }
}