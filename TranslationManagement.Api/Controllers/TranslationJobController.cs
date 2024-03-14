using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TranslationManagement.Api.Controllers.Base;
using TranslationManagement.BusinessLogic.Services.Interfaces;
using TranslationManagement.ViewModels.TranslationJob;

namespace TranslationManagement.Api.Controllers
{
    public class TranslationJobController : BaseApiController
    {
        private readonly ITranslationJobService _translationJobService;

        public TranslationJobController(ITranslationJobService translationJobServic)
        {
            _translationJobService = translationJobServic;
        }

        /// <summary>
        /// Retrieves all translation jobs.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            ResponseGetListTranslationJobModel result = await _translationJobService.GetList();
            return Ok(result);
        }

        /// <summary>
        /// Adds a new translation job to the database.
        /// </summary>
        /// <param name="requestModel">The translation job to add.</param>
        [HttpPost]
        public async Task<IActionResult> CreateJob([FromBody] RequestCreateTranslationJobModel requestModel)
        {
            await _translationJobService.Create(requestModel);
            return NoContent();
        }

        /// <summary>
        /// Adds a new translation job from file to the database.
        /// </summary>
        /// <param name="requestModel">The create translation job information.</param>
        [HttpPost]
        public async Task<IActionResult> CreateJobWithFile([FromForm] RequestCreateWithFileTranslationJobModel requestModel)
        {
            await _translationJobService.CreateWithFile(requestModel);
            return NoContent();
        }

        /// <summary>
        /// Updates an existing translation job status in the database.
        /// </summary>
        /// <param name="requestModel">The updated translation job information.</param>
        [HttpPost]
        public async Task<IActionResult> UpdateJobStatus([FromBody] RequestUpdateStatusTranslationJobModel requestModel)
        {
            await _translationJobService.UpdateStatus(requestModel);
            return NoContent();
        }

        /// <summary>
        /// Assigns an existing translator to the translation job.
        /// </summary>
        /// <param name="requestModel">The assign information.</param>
        [HttpPost]
        public async Task<IActionResult> AssignJob([FromBody] RequestAssignTranslationJobModel requestModel)
        {
            await _translationJobService.Assign(requestModel);
            return NoContent();
        }

    }
}