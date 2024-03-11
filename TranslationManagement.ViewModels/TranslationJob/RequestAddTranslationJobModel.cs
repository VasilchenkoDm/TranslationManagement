using System.ComponentModel.DataAnnotations;

namespace TranslationManagement.ViewModels.TranslationJob
{
    public class RequestAddTranslationJobModel
    {
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string OriginalContent { get; set; }
        [Required]
        public string TranslatedContent { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
