using AspnetWebapiAzureDeploy.Api2;
using AspnetWebapiAzureDeploy.Api2.Controllers;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AspnetWebapiAzureDeploy.Api2Test
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
