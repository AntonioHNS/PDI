using Microsoft.AspNetCore.Mvc;
using PDI.Models;
using PDI.Services;

namespace PDI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BotController : ControllerBase
    {
        private readonly IBlipService _blipService;

        public BotController(IBlipService blipService, IServiceProvider serviceProvider)
        {
            _blipService = blipService;
        }

        [HttpPost]
        [Route("/copyAttendance")]
        public IActionResult CopyAttendance([FromBody] CopyConfigurationRequest copyConfigurationRequest)
        {
            try
            {
                var CreationInTarget = new List<QueueCreateResult>();
                var queuesFromOrigin = _blipService.GetAttendanceQueuesAsync(copyConfigurationRequest.OriginTenant, copyConfigurationRequest.OriginAuthorization).Result;
                if (!queuesFromOrigin.Any())
                {
                    return NoContent();
                }
                CreationInTarget = _blipService.CreateQueuesAsync(copyConfigurationRequest.TargetTenant, copyConfigurationRequest.TargetAuthorization, queuesFromOrigin).Result;
                return Ok(CreationInTarget);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
