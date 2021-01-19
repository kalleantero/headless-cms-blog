using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using HeadlessBlog.Web.Models;
using System.Threading.Tasks;

namespace HeadlessBlog.Web.Components
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly AppSettings _appSettings;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public FooterViewComponent(IOptions<AppSettings> settings, IStringLocalizer<SharedResources> localizer)
        {
            _appSettings = settings.Value;
            _localizer = localizer;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.StringLocalizer = _localizer;

            return View(new {
                TwitterUrl = _appSettings.TwitterUrl,
                LinkedInUrl = _appSettings.LinkedInUrl,
                GithubUrl = _appSettings.GithubUrl,
                FooterCopyright = _appSettings.FooterCopyright
            });
        }
    }
}
