using System;
using Microsoft.AspNetCore.Mvc;
using Test.DTOs.Request;
using Test.Exceptions;
using Test.Services;

namespace Test.Controllers
{
    [ApiController]
    [Route("api/actions/1")]
    public class ActionController : ControllerBase
    {
        private readonly IActionService _service;

        public ActionController(IActionService service)
        {
            _service = service;
        }
        
        [HttpPost]
        [Route("fire-truck")]
        public IActionResult AddFireTruckToAction(AssignFireTruckToActionRequestDto dto)
        {
            try
            {
                return Ok(_service.AddFireTruckToAction(dto));
            }
            catch (ResourceNotFoundException e)
            {
                return NotFound(e);
            }
        }
        
        
    }
}