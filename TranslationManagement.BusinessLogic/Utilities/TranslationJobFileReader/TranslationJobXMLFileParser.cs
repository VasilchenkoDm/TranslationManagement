using System.Reflection.PortableExecutable;
using System.Xml.Linq;
using TranslationManagement.BusinessLogic.Utilities.TranslationJobFileReader.Interfaces;
using TranslationManagement.DataAccess.Entities;

namespace TranslationManagement.BusinessLogic.Utilities.TranslationJobFileReader
{
    public class TranslationJobXMLFileParser : ITranslationJobFileParser
    {
        public TranslationJobModel Parse(StreamReader streamReader)
        {
            var translationJob = new TranslationJobModel();

            var xdoc = XDocument.Parse(streamReader.ReadToEnd());
            translationJob.Content = xdoc.Root.Element("Content").Value;
            translationJob.Customer = xdoc.Root.Element("Customer").Value.Trim();

            return translationJob;
        }
    }
}

