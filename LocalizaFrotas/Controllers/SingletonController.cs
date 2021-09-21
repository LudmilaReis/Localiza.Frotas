using Localiza.Frotas.Infra.Singleton;
using Microsoft.AspNetCore.Mvc;

namespace Localiza.Frotas.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SingletonController : ControllerBase
    {
        public SingletonController(SingletonContainer singletonContainer)
        {
            SingletonContainer = singletonContainer;
        }

        public SingletonContainer SingletonContainer { get; }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return id switch
            {
                1 => Ok(SingletonContainer),
                _ => Ok(Singleton.Instance)
            };
        }
    }
}
