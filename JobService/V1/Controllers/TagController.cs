namespace JobService.API.V1.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using JobService.Core.Agents;
    using JobService.Core.Models;

    /// <summary>
    /// 
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IAgent<HangfireTag> _tagAgent;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="tagAgent"></param>
        public TagController(ILogger<JobController> logger, IAgent<HangfireTag> tagAgent)
        {
            _logger = logger;
            _tagAgent = tagAgent;
        }

        /// <summary>
        /// Get all tags
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            return Ok(_tagAgent.GetAll());
        }
    }
}