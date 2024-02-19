using Microsoft.AspNetCore.Mvc;
using ReflactionMediatr.API.Models.User;
using ReflactionMediatr.API.User.Queries;
using ReflactionMediatr.Lib.Interface.Mediator;

namespace ReflactionMediatr.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ICustomReflaction _customReflaction;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ICustomReflaction customReflaction)
        {
            _logger = logger;
            _customReflaction = customReflaction;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public Task<UserViewModel> Get()
        {
            return _customReflaction.Send(new GetUserByIdQuery(10));
        }
    }
}
