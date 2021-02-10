using AspnetWebapiAzureDeploy.Api1;
using AspnetWebapiAzureDeploy.Api1.Controllers;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AspnetWebapiAzureDeploy.Api1Test
{
    public class WeatherForecastControllerTest
    {
        [Fact]
        public void GetTest()
        {
            WeatherForecastController weatherForecastController = new();

            IEnumerable<WeatherForecast> weatherForecasts = weatherForecastController.Get();

            Assert.NotNull(weatherForecasts);
            Assert.Equal(5, weatherForecasts.Count());
        }
    }
}
