using TranslationManagement.DataAccess.Entities.Base;

namespace TranslationManagement.DataAccess.Entities
{
    public class TranslationJob : BaseEntity
    {
        public string CustomerName { get; set; }
        public string Status { get; set; }
        public string OriginalContent { get; set; }
        public string TranslatedContent { get; set; }
        public double Price { get; set; }
    }
}
