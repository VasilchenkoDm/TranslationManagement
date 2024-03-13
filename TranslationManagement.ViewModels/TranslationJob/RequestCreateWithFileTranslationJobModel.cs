using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace TranslationManagement.ViewModels.TranslationJob
{
    public class RequestCreateWithFileTranslationJobModel
    {
        [Required]
        public string CustomerName { get; set; }
        public IFormFile File { get; set; }
    }
}
