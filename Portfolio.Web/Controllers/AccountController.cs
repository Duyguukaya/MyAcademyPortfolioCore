using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using System.Security.Claims;

namespace Portfolio.Web.Controllers
{
    [Authorize] // sadece giriş yapmış kullanıcılar erişebilir
    public class AccountController : Controller
    {
        private readonly PortfolioContext _context;

        public AccountController(PortfolioContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult UpdateProfile(string Username, string CurrentPassword, string NewPassword, string ConfirmPassword)
        {
            var currentUserName = User.Identity?.Name;
            var user = _context.Users.FirstOrDefault(u => u.UserName == currentUserName);

            if (user == null) return Unauthorized();

            // mevcut şifre doğru mu kontrol et
            if (user.Password != CurrentPassword)
            {
                TempData["Error"] = "Mevcut şifre hatalı.";
                return RedirectToAction("Index", "Statistics");
            }

            // kullanıcı adını güncelle
            user.UserName = Username;

            // yeni şifre girildiyse değiştir
            if (!string.IsNullOrEmpty(NewPassword))
            {
                if (NewPassword != ConfirmPassword)
                {
                    TempData["Error"] = "Yeni şifreler uyuşmuyor.";
                    return RedirectToAction("Index", "Statistics");
                }

                user.Password = NewPassword;
            }

            _context.SaveChanges();
            TempData["Success"] = "Profil başarıyla güncellendi.";

            return RedirectToAction("Index", "Statistics");
        }
    }
}
