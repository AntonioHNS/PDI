using Microsoft.AspNetCore.Mvc;
using PDI.Models;

namespace PDI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BotController : ControllerBase
    {
        [HttpPost]
        [Route("/copyAttendance")]
        public IActionResult CopyAttendance([FromBody] CopyConfigurationRequest copyConfigurationRequest)
        {
            try
            {
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
