using AutoMapper;

namespace Blog.Mappings
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<Entities.Author, ViewModels.AuthorViewModel>()
                .ForMember(dst => dst.FullName, cfg => cfg.MapFrom(src => src.Name + " " + src.FirstName + " " + src.LastName));

            CreateMap<Entities.Author, ViewModels.AuthorDetailViewModel>()
                .ForMember(dst => dst.Posts, cfg => cfg.MapFrom(src => src.Posts.Count))
                .ForMember(dst => dst.Comments, cfg => cfg.MapFrom(src => src.Comments.Count));

            CreateMap<Entities.Author, ViewModels.AuthorEditFormViewModel>();

            CreateMap<Entities.Post, ViewModels.PostViewModel>();
        }
    }
}