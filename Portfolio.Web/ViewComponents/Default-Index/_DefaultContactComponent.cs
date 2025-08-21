using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;

namespace Portfolio.Web.Views.Default
{
    public class _DefaultContactComponent(PortfolioContext context):ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var contects = context.ContactInfos.ToList();
            return View(contects);
        }
    }
}
