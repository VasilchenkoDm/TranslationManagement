using System.ComponentModel.DataAnnotations;

namespace TranslationManagement.ViewModels.TranslationJob
{
    public class RequestUpdateStatusTranslationJobModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int TranslatorId { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
