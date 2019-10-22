namespace JobService.API.V1.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using JobService.API.V1.Models;
    using JobService.Core.Factories;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// Trigger jobs using this controller
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IJobFactory _jobFactory;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="jobFactory"></param>
        public JobController(ILogger<JobController> logger, IJobFactory jobFactory)
        {
            _logger = logger;
            _jobFactory = jobFactory;
        }

        /// <summary>
        /// Add recurring jobs
        /// </summary>
        /// <param name="jobConfiguration">Batch with Http and Stored Procedure jobs</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("recurring")]
        public IActionResult AddRecurringJobs([FromBody] JobConfiguration jobConfiguration, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Initializing recurring jobs. Configuration:{JsonConvert.SerializeObject(jobConfiguration)}");

                jobConfiguration?.HttpJobs.Select(job => _jobFactory.GenerateRecurringJob(job, cancellationToken)).ToArray();
                jobConfiguration?.StoredProcedureJobs.Select(job => _jobFactory.GenerateRecurringJob(job, cancellationToken)).ToArray();

                _logger.LogInformation($"Initializing recurring jobs successful.");

                return Ok();
            }
            catch (System.Exception e)
            {
                _logger.LogError($"Initializing recurring jobs unsuccessful. Exception:{e}");

                throw e;
            }
        }

        /// <summary>
        /// Add fire-and-forget jobs
        /// </summary>
        /// <param name="jobConfiguration">Batch with Http and Stored Procedure jobs</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("fire-and-forget")]
        public IActionResult AddFireAndForgetJobs([FromBody] JobConfiguration jobConfiguration, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Initializing fire-and-forget jobs. Configuration:{JsonConvert.SerializeObject(jobConfiguration)}");

                jobConfiguration?.HttpJobs.Select(job => _jobFactory.GenerateFireAndForgetJob(job, cancellationToken)).ToArray();
                jobConfiguration?.StoredProcedureJobs.Select(job => _jobFactory.GenerateFireAndForgetJob(job, cancellationToken)).ToArray();

                _logger.LogInformation($"Initializing fire-and-forget jobs successful.");

                return Ok();
            }
            catch (System.Exception e)
            {
                _logger.LogError($"Initializing fire-and-forget jobs unsuccessful. Exception:{e}");

                throw e;
            }
        }

        /// <summary>
        /// Add delayed jobs
        /// </summary>
        /// <param name="jobConfiguration">Batch with Http and Stored Procedure jobs</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("delayed")]
        public IActionResult AddDelayedJobs([FromBody] JobConfiguration jobConfiguration, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Initializing delayed jobs. Configuration:{JsonConvert.SerializeObject(jobConfiguration)}");

                jobConfiguration?.HttpJobs.Select(job => _jobFactory.GenerateDelayedJob(job, cancellationToken)).ToArray();
                jobConfiguration?.StoredProcedureJobs.Select(job => _jobFactory.GenerateDelayedJob(job, cancellationToken)).ToArray();

                _logger.LogInformation($"Initializing delayed jobs successful.");

                return Ok();
            }
            catch (System.Exception e)
            {
                _logger.LogError($"Initializing delayed jobs unsuccessful. Exception:{e}");

                throw e;
            }
        }
    }
}