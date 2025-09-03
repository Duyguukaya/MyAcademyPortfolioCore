using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Controllers
{
    public class BannerController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
           var banners= context.Banners.ToList();
            return View(banners);
        }

        public IActionResult CreateBanner()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBanner(Banner model)
        {
            context.Banners.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteBanner(int id) 
        {
            var banners = context.Banners.Find(id);
            context.Banners.Remove(banners);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UpdateBanner(int id)
        {
            var banners = context.Banners.Find(id);
            return View(banners);
        }

        [HttpPost]
        public IActionResult UpdateBanner(Banner model)
        {
            context.Update(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
