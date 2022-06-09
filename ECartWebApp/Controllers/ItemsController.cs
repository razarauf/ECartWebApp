using ECartWebApp.Models;
using ECartWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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

        public ActionResult New()
        {
            ItemViewModel itemViewModel = new ItemViewModel();
            itemViewModel.CategoriesList = _dbContext.Categories.Select(eachCategory => new SelectListItem
            {
                Value = eachCategory.Id.ToString(),
                Text = eachCategory.CategoryName
            }).ToList();
            return View(itemViewModel);
        }

        [HttpPost]
        public JsonResult PostToThis (ItemViewModel itemVM)
        {
            string newImage = Guid.NewGuid() + Path.GetExtension(itemVM.Image.FileName);
            itemVM.Image.SaveAs(Server.MapPath("~/Images/" + newImage));

            Item item = new Item();
            item.ImageURL = "~/Images/" + newImage;
            item.CategoryId = itemVM.CategoryId;
            item.Description = itemVM.Description;
            item.ItemCode = itemVM.ItemCode;
            item.ItemName = itemVM.ItemName;
            item.ItemPrice = itemVM.ItemPrice;
            _dbContext.Items.Add(item);
            _dbContext.SaveChanges();

            return Json(new { Message = "Data Saved." }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit()
        {
            ViewBag.categories = new SelectList(_dbContext.Categories.ToList(), "ID", "CategoryName");

            return View();
        }
    }
}