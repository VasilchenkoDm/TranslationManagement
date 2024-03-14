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

        /// <summary>
        /// Retrieves all translators.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetTranslators()
        {
            ResponseGetListTranslatorModel result = await _translatorService.GetList();
            return Ok(result);
        }

        /// <summary>
        /// Retrieves all translators by the translator name.
        /// </summary>
        /// <param name="translatorName">The translator name.</param>
        [HttpGet]
        public async Task<IActionResult> GetTranslatorsByName(string translatorName)
        {
            ResponseGetListTranslatorModel result = await _translatorService.GetList(translatorName);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves all translators by the translator status.
        /// </summary>
        /// <param name="translatorStatus">The translator status.</param>
        [HttpGet]
        public async Task<IActionResult> GetTranslatorsByStatus(string translatorStatus)
        {
            ResponseGetListTranslatorModel result = await _translatorService.GetList(string.Empty, translatorStatus);
            return Ok(result);
        }

        /// <summary>
        /// Adds a new translator to the database.
        /// </summary>
        /// <param name="requestModel">The create translator information.</param>
        [HttpPost]
        public async Task<IActionResult> CreateTranslator([FromBody] RequestCreateTranslatorModel requestModel)
        {
            await _translatorService.Create(requestModel);
            return NoContent();
        }

        /// <summary>
        /// Updates an existing translator status in the database.
        /// </summary>
        /// <param name="requestModel">The updated translator information.</param>
        [HttpPost]
        public async Task<IActionResult> UpdateTranslatorStatus([FromBody] RequestUpdateStatusTranslatorModel requestModel)
        {
            await _translatorService.UpdateStatus(requestModel);
            return NoContent();
        }

    }
}