namespace TranslationManagement.ViewModels.Translator
{
    public class ResponseGetListTranslatorModel
    {
        public IEnumerable<GetListTranslatorModelItem> Items { get; set; }
    }

    public class GetListTranslatorModelItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HourlyRate { get; set; }
        public string Status { get; set; }
        public string CreditCardNumber { get; set; }
    }
}
