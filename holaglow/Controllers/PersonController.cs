using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Names.API_Holaglow.Controllers
{
	[ApiController]
    [Route("api")]
    public class PersonController : ControllerBase
	{
        private readonly IPersonList _personList;

        public PersonController(IPersonList personList)
        {
            _personList = personList;
        }

        [HttpGet]
		[Route("names")]
        public IActionResult Filter([FromQuery] string? gender, [FromQuery] string? name)
        {
            var result = _personList.GetList(gender, name);

            if (result != null)
            {
                return Ok(result);
            }

            return StatusCode(500, "Error interno del servidor");
        }
    }
}

