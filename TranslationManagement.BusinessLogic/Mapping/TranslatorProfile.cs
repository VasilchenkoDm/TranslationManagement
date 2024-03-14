using AutoMapper;
using TranslationManagement.DataAccess.Entities;
using TranslationManagement.ViewModels.Translator;

namespace TranslationManagement.BusinessLogic.Mapping
{
    public class TranslatorProfile : Profile
    {
        public TranslatorProfile()
        {
            CreateMap<Translator, GetListTranslatorModelItem>();
            CreateMap<RequestCreateTranslatorModel, Translator>();
        }
    }
}
