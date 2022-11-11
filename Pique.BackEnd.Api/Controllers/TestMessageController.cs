using DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Pique.BackEnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestMessageController : ControllerBase
    {
        private IServicesTest _services;

        public TestMessageController(IServicesTest services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_services.GetMessage());
            }
            catch (System.Exception)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
