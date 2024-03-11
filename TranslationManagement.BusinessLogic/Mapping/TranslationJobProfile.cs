using AutoMapper;
using TranslationManagement.DataAccess.Entities;
using TranslationManagement.ViewModels.TranslationJob;

namespace TranslationManagement.BusinessLogic.Mapping
{
    public class TranslationJobProfile : Profile
    {
        public TranslationJobProfile()
        {
            CreateMap<TranslationJob, GetListTranslationJobModelItem>();
            CreateMap<RequestAddTranslationJobModel, Translator>();
        }
    }
}
