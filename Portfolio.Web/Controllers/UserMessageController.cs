using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Web.Context;

namespace Portfolio.Web.Controllers
{
    public class UserMessageController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
            var message = context.UserMessages.ToList();
            return View(message);
        }

        [HttpPost]
        public IActionResult MarkAsRead(int id)
        {
            var message = context.UserMessages.FirstOrDefault(x => x.UserMessageId == id);
            if (message != null)
            {
                message.IsRead = true;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var message = context.UserMessages.FirstOrDefault(x => x.UserMessageId == id);
            if (message != null)
            {
                context.UserMessages.Remove(message);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
