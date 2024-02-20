using Microsoft.AspNetCore.Mvc;
using ReflactionMediatr.API.Models.User;
using ReflactionMediatr.API.User.Queries;
using ReflactionMediatr.Lib.Interface.Mediator;

namespace ReflactionMediatr.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        private readonly ILogger<HomeController> _logger;
        private readonly ICustomReflaction _customReflaction;

        public HomeController(ILogger<HomeController> logger, ICustomReflaction customReflaction)
        {
            _logger = logger;
            _customReflaction = customReflaction;
        }

        [HttpGet(Name = "Get")]
        public Task<UserViewModel> Get()
        {
            return _customReflaction.Send(new GetUserByIdQuery(10));
        }
    }
}
