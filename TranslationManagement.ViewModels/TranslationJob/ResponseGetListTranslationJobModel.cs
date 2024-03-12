namespace TranslationManagement.ViewModels.TranslationJob
{
    public class ResponseGetListTranslationJobModel
    {
        public IEnumerable<GetListTranslationJobModelItem> Items { get; set; }
    }

    public class GetListTranslationJobModelItem
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Status { get; set; }
        public string OriginalContent { get; set; }
        public string TranslatedContent { get; set; }
        public double Price { get; set; }
        public string TranslatorName { get; set; }
    }
}
