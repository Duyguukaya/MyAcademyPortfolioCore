using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Portfolio.Web.Context;

namespace Portfolio.Web.Controllers
{
    public class StatisticsController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
            ViewBag.projectCount = context.Projects.Count();
            ViewBag.skillAverage = context.Skills.Any() ? context.Skills.Average(x=>x.Percentage).ToString("00.00") : 0.0.ToString("00.00");
            ViewBag.unreadMessageCount = context.UserMessages.Count(x => x.IsRead == false);
            ViewBag.lastMessageOwner = context.UserMessages.OrderByDescending(x => x.UserMessageId).Select(x=>x.Name).FirstOrDefault();

            // 1. Verileri çek
            var startYearStrings = context.Experiences
                .Where(x => !string.IsNullOrEmpty(x.StartYear))
                .Select(x => x.StartYear)
                .ToList(); // Artık bellekteyiz

            // 2. Sadece yılı al
            var years = startYearStrings
                .Select(x => int.Parse(x.Substring(x.Length - 4))) // son 4 karakter = yıl
                .ToList();

            // 3. Minimum yılı bul
            var startYear = years.Min();

            // 4. Deneyim yılı hesapla
            ViewBag.experienceYear = DateTime.Now.Year - startYear;
            ViewBag.companyCount = context.Experiences.Select(x => x.Company).Distinct().Count();
            ViewBag.reviewAverage = context.Testimonials.Any() ? context.Testimonials.Average(x => x.Review).ToString("0.0") : "değerlendirme yapılmadı";
            ViewBag.maxReviewOwner = context.Testimonials.OrderByDescending(x => x.Review).Select(x => x.Name).FirstOrDefault();


            return View();
        }
    }
}
