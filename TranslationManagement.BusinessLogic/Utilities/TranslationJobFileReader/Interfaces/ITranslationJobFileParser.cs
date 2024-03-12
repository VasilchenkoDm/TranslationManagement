namespace TranslationManagement.BusinessLogic.Utilities.TranslationJobFileReader.Interfaces
{
    public interface ITranslationJobFileParser
    {
        TranslationJobModel Parse(StreamReader streamReader);
    }
}
