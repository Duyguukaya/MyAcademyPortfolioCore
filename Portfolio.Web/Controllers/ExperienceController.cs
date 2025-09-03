using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Controllers
{
    public class ExperienceController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
            var experience = context.Experiences.ToList();
            return View(experience);
        }

        public IActionResult CreateExperience()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateExperience(Experience model)
        {
            context.Experiences.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteExperience(int id)
        {
            var experience = context.Experiences.Find(id);
            context.Experiences.Remove(experience);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UpdateExperience(int id)
        {
            var experience = context.Experiences.Find(id);
            return View(experience);
        }

        [HttpPost]
        public IActionResult UpdateExperience(Experience model)
        {
            context.Experiences.Update(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    
}
}
