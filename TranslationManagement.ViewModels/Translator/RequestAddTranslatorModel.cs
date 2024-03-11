using System.ComponentModel.DataAnnotations;

namespace TranslationManagement.ViewModels.Translator
{
    public class RequestAddTranslatorModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string HourlyRate { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string CreditCardNumber { get; set; }
    }
}
