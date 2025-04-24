using Microsoft.AspNetCore.Mvc;

namespace ThinkEdu_Core_Service.Api.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private readonly ILogger<BaseApiController> _logger;
        public BaseApiController(ILogger<BaseApiController> logger)
        {
            _logger = logger;
        }
    }
}