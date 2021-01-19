using ButterCMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using HeadlessBlog.Web.Models;
using System.Linq;
using System.Threading.Tasks;

namespace HeadlessBlog.Web.Components
{
    public class TopNavigationViewComponent : ViewComponent
    {
        private ButterCMSClient _cmsClient;
        private readonly AppSettings _appSettings;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public TopNavigationViewComponent(IOptions<AppSettings> settings, IStringLocalizer<SharedResources> localizer)
        {
            _appSettings = settings.Value;
            _localizer = localizer;

            if (!string.IsNullOrEmpty(_appSettings.ButterCmsApiKey))
            {
                _cmsClient = new ButterCMSClient(_appSettings.ButterCmsApiKey);
            }
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.StringLocalizer = _localizer;

            if (string.IsNullOrEmpty(_appSettings.ContentPageName))
                return View();

            var pagesResponse = await _cmsClient?.ListPagesAsync<ContentPage>(_appSettings.ContentPageName);  
              
            return View(pagesResponse?.Data?.OrderBy(x => x.Fields.NavigationTitle));
        }
    }
}
