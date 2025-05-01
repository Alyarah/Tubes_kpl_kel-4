using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tubes_kpl_kel_4.Models;

namespace Tubes_kpl_kel_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
            [HttpPost]
            public IActionResult KirimFeedback([FromBody] FeedbackRequest request)
            {
                return Ok("Terima kasih atas feedback Anda!");
            }
        
    }

}

