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
            bool result = await _translationJobService.Add(requestModel);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateJobWithFile([FromForm] RequestAddWithFileTranslationJobModel requestModel)
        {
            bool result = await _translationJobService.AddWithFile(requestModel);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateJobStatus([FromBody] RequestUpdateStatusTranslationJobModel requestModel)
        {
            string result = await _translationJobService.UpdateStatus(requestModel);
            return Ok(result);
        }

    }
}