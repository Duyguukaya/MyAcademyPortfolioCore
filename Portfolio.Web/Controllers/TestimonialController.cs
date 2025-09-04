using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Controllers
{
    public class TestimonialController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
            var testimonials = context.Testimonials.ToList();
            return View(testimonials);
        }

        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTestimonial(Testimonial model)
        {
            context.Testimonials.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteTestimonial(int id)
        {
            var testimonials = context.Testimonials.Find(id);
            context.Testimonials.Remove(testimonials);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UpdateTestimonial(int id)
        {
            var testimonials = context.Testimonials.Find(id);
            return View(testimonials);
        }

        [HttpPost]
        public IActionResult UpdateTestimonial(Testimonial model)
        {
            context.Testimonials.Update(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
