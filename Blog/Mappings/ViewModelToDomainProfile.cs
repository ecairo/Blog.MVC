using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Mappings
{
    public class ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<ViewModels.AuthorFormViewModel, Entities.Author>();

            CreateMap<ViewModels.AuthorEditFormViewModel, Entities.Author>();

            CreateMap<ViewModels.RegisterViewModel, Entities.Author>();
        }
    }
}