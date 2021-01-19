using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using HeadlessBlog.Web.Models;

namespace HeadlessBlog.Web.Components
{
    public class BaseViewComponent : ViewComponent
    {
        public readonly AppSettings _appSettings;
        public readonly IStringLocalizer<SharedResources> _localizer;

        public BaseViewComponent(IOptions<AppSettings> settings, IStringLocalizer<SharedResources> localizer)
        {
            _appSettings = settings.Value;
            _localizer = localizer;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.StringLocalizer = _localizer;
            return View();
        }
    }
}
