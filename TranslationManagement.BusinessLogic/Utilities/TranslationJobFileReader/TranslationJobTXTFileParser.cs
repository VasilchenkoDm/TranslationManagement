using System.Reflection.PortableExecutable;
using TranslationManagement.BusinessLogic.Utilities.TranslationJobFileReader.Interfaces;

namespace TranslationManagement.BusinessLogic.Utilities.TranslationJobFileReader
{
    public class TranslationJobTXTFileParser : ITranslationJobFileParser
    {
        public TranslationJobModel Parse(StreamReader streamReader)
        {
            var translationJob = new TranslationJobModel();
            translationJob.Content = streamReader.ReadToEnd();
            return translationJob;
        }
    }
}
