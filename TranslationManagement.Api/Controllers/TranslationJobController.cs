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

        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            ResponseGetListTranslationJobModel result = await _translationJobService.GetList();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateJob([FromBody] RequestAddTranslationJobModel requestModel)
        {
            await _translationJobService.Add(requestModel);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateJobWithFile([FromForm] RequestAddWithFileTranslationJobModel requestModel)
        {
            await _translationJobService.AddWithFile(requestModel);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateJobStatus([FromBody] RequestUpdateStatusTranslationJobModel requestModel)
        {
            await _translationJobService.UpdateStatus(requestModel);
            return NoContent();
        }

    }
}