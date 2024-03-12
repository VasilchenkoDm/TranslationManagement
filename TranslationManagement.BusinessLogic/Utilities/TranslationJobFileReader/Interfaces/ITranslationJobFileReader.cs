using Microsoft.AspNetCore.Http;

namespace TranslationManagement.BusinessLogic.Utilities.TranslationJobFileReader.Interfaces
{
    public interface ITranslationJobFileReader
    {
        TranslationJobModel ReadFile(IFormFile file);
    }
}
