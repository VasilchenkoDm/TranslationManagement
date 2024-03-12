using TranslationManagement.DataAccess.Entities.Base;
using TranslationManagement.Shared.Enums;

namespace TranslationManagement.DataAccess.Entities
{
    public class Translator : BaseEntity
    {
        public string Name { get; set; }
        public string HourlyRate { get; set; }
        public TranslatorStatusEnum Status { get; set; }
        public string CreditCardNumber { get; set; }
        public ICollection<TranslationJob> TranslationJobs { get; set; }
    }
}
