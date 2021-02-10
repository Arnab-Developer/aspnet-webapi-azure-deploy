using AspnetWebapiAzureDeploy.Api2;
using AspnetWebapiAzureDeploy.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AspnetWebapiAzureDeploy.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiUrl _apiUrl;

        public HomeController(
            ILogger<HomeController> logger,
            IHttpClientFactory httpClientFactory,
            IOptionsMonitor<ApiUrl> optionsMonitor)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _apiUrl = optionsMonitor.CurrentValue;
        }

        public async Task<IActionResult> Index()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();

            string summary1 = string.Empty;
            string summary2 = string.Empty;

            HttpResponseMessage api1ResponseMessage = await httpClient.GetAsync(_apiUrl.Api1);
            if (api1ResponseMessage.IsSuccessStatusCode)
            {
                using Stream api1ResponseStream = await api1ResponseMessage.Content.ReadAsStreamAsync();
                IEnumerable<WeatherForecast>? models1
                    = await JsonSerializer.DeserializeAsync<IEnumerable<WeatherForecast>>(api1ResponseStream);
                if (models1 != null)
                {
                    summary1 = models1.ElementAt(0).Summary;
                }
            }

            HttpResponseMessage api2ResponseMessage = await httpClient.GetAsync(_apiUrl.Api2);
            if (api2ResponseMessage.IsSuccessStatusCode)
            {
                using Stream api2ResponseStream = await api2ResponseMessage.Content.ReadAsStreamAsync();
                IEnumerable<WeatherForecast>? models2
                    = await JsonSerializer.DeserializeAsync<IEnumerable<WeatherForecast>>(api2ResponseStream);
                if (models2 != null)
                {
                    summary2 = models2.ElementAt(0).Summary;
                }
            }

            return View(new WeatherSummary
            {
                Summary1 = summary1,
                Summary2 = summary2
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
