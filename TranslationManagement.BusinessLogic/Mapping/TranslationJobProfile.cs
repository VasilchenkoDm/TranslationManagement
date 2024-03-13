using AutoMapper;
using TranslationManagement.DataAccess.Entities;
using TranslationManagement.ViewModels.TranslationJob;

namespace TranslationManagement.BusinessLogic.Mapping
{
    public class TranslationJobProfile : Profile
    {
        public TranslationJobProfile()
        {
            CreateMap<TranslationJob, GetListTranslationJobModelItem>()
                .ForMember(x => x.TranslatorName, opt => opt.MapFrom(src => src.Translator.Name));
            CreateMap<RequestCreateTranslationJobModel, TranslationJob>();
        }
    }
}
