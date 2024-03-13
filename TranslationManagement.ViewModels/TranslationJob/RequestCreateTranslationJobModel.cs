using System.ComponentModel.DataAnnotations;

namespace TranslationManagement.ViewModels.TranslationJob
{
    public class RequestCreateTranslationJobModel
    {
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string OriginalContent { get; set; }
    }
}
