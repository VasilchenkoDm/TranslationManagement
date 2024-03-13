using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TranslationManagement.Api.Controllers.Base;
using TranslationManagement.BusinessLogic.Services;
using TranslationManagement.BusinessLogic.Services.Interfaces;
using TranslationManagement.ViewModels.Translator;

namespace TranslationManagement.Api.Controlers
{
    public class TranslatorManagementController : BaseApiController
    {
        private readonly ITranslatorService _translatorService;

        public TranslatorManagementController(ITranslatorService translatorService)
        {
            _translatorService = translatorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTranslators()
        {
            ResponseGetListTranslatorModel result = await _translatorService.GetList();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetTranslatorsByName(string translatorName)
        {
            ResponseGetListTranslatorModel result = await _translatorService.GetList(translatorName);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetTranslatorsByStatus(string translatorStatus)
        {
            ResponseGetListTranslatorModel result = await _translatorService.GetList(string.Empty, translatorStatus);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddTranslator([FromBody] RequestAddTranslatorModel requestModel)
        {
            await _translatorService.Add(requestModel);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTranslatorStatus([FromBody] RequestUpdateStatusTranslatorModel requestModel)
        {
            await _translatorService.UpdateStatus(requestModel);
            return NoContent();
        }

    }
}