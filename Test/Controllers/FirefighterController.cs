using Microsoft.AspNetCore.Mvc;
using Test.Exceptions;
using Test.Services;


namespace Test.Controllers
{
    [ApiController]
    [Route("api/firefighters/1")]
    public class TestController : ControllerBase
    {
        private readonly IFirefighterService _service;

        public TestController(IFirefighterService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("actions")]
        public IActionResult GetFirefighterActions(int idFirefighter)
        {
            try
            {
                return Ok(_service.GetAllFirefighterActions(idFirefighter));
            }
            catch (ResourceNotFoundException e)
            {
                return NotFound(e);
            }
        }
        
    }
}