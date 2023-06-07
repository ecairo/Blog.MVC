using AutoMapper;

namespace Blog.Mappings
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<Entities.Author, ViewModels.AuthorViewModel>()
                .ForMember(dst => dst.FullName, cfg => cfg.MapFrom(src => src.Name + " " + src.FirstName + " " + src.LastName));
        }
    }
}