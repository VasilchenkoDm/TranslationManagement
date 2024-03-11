using System.ComponentModel.DataAnnotations;

namespace TranslationManagement.ViewModels.Translator
{
    public class RequestUpdateStatusTranslatorModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
