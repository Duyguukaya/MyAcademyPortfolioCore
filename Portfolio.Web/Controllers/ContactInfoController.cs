using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Controllers
{
    public class ContactInfoController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
           var contacts= context.ContactInfos.ToList();
            return View(contacts);
        }

        public IActionResult CreateContactInfo()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult CreateContactInfo(ContactInfo model)
        {
            context.ContactInfos.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteContactInfo(int id)
        {
            var contacts = context.ContactInfos.Find(id);
            context.ContactInfos.Remove(contacts);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

   
        public IActionResult UpdateContactInfo(int id)
        {
            var contacts = context.ContactInfos.Find(id);
            return View(contacts);
        }

        [HttpPost]
        public IActionResult UpdateContactInfo(ContactInfo model)
        {
           context.ContactInfos.Update(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
