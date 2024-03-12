using Microsoft.AspNetCore.Http;
using System.Xml.Linq;
using TranslationManagement.BusinessLogic.Utilities.TranslationJobFileReader.Interfaces;
using TranslationManagement.DataAccess.Entities;

namespace TranslationManagement.BusinessLogic.Utilities.TranslationJobFileReader
{
    public class TranslationJobFileReader : ITranslationJobFileReader
    {
        private ITranslationJobFileParser _fileParser;

        public TranslationJobModel ReadFile(IFormFile file)
        {
            if (file.FileName.EndsWith(".txt"))
            {
                _fileParser = new TranslationJobTXTFileParser();
            }
            else if (file.FileName.EndsWith(".xml"))
            {
                _fileParser = new TranslationJobXMLFileParser();
            }
            else
            {
                throw new NotSupportedException("unsupported file");
            }

            var reader = new StreamReader(file.OpenReadStream());
            var translationJob = new TranslationJobModel();
            translationJob = _fileParser.Parse(reader);
            return translationJob;
        }
    }
}