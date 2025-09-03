using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Controllers
{
    public class SkillController(PortfolioContext context) : Controller
    {

        public IActionResult Index()
        {
            var skills = context.Skills.ToList();
            return View(skills);
        }

        public IActionResult CreateSkill()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CreateSkill(Skill model)
        {
            context.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSkill(int id)
        {
            var skill = context.Skills.Find(id);
            context.Skills.Remove(skill);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UpdateSkill(int id)
        {
            var skill = context.Skills.Find(id);
            return View(skill);
        }

        [HttpPost]
        public IActionResult UpdateSkill(Skill model)
        {
            context.Update(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
