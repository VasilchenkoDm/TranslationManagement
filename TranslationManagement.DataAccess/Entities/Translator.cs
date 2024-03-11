using TranslationManagement.DataAccess.Entities.Base;

namespace TranslationManagement.DataAccess.Entities
{
    public class Translator : BaseEntity
    {
        public string Name { get; set; }
        public string HourlyRate { get; set; }
        public string Status { get; set; }
        public string CreditCardNumber { get; set; }
    }
}
