using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Interfaces;

namespace Api.Controllers
{
    
    public class DateTimeController : BaseController
    {
        private readonly IDateTimeService _service;
        public DateTimeController(IDateTimeService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetDateTime")]
        public IActionResult GetDateTime()
        {
            var result = _service.GetCurrentDateTime();
            return Ok(result);
        }
    }
}
