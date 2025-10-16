using Microsoft.AspNetCore.Mvc;

namespace Lab14.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { message = "CORS is working!", timestamp = DateTime.UtcNow });
        }

        [HttpPost]
        public IActionResult Post([FromBody] object data)
        {
            return Ok(new { 
                message = "POST request received successfully", 
                receivedData = data,
                timestamp = DateTime.UtcNow 
            });
        }
    }
} 