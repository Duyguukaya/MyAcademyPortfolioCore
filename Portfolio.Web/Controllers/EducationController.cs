using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Controllers
{
    public class EducationController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
            var educations = context.Educations.ToList();
            return View(educations);
        }

        public IActionResult CreateEducation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEducation(Education model)
        {
            context.Educations.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteEducation(int id)
        {
            var education = context.Educations.Find(id);
            context.Educations.Remove(education);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UpdateEdication(int id)
        {
            var education = context.Educations.Find(id);
            return View(education);
        }

        [HttpPost]
        public IActionResult UpdateEdication(Education model)
        {
           context.Educations.Update(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
