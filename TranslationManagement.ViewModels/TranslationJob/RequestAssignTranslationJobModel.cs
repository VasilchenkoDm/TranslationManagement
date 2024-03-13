using System.ComponentModel.DataAnnotations;

namespace TranslationManagement.ViewModels.TranslationJob
{
    public class RequestAssignTranslationJobModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int TranslatorId { get; set; }
    }
}
