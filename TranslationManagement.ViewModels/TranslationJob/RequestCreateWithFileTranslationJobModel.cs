using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace TranslationManagement.ViewModels.TranslationJob
{
    public class RequestCreateWithFileTranslationJobModel
    {
        public string CustomerName { get; set; }
        [Required]
        public IFormFile File { get; set; }
    }
}
