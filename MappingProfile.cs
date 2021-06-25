using AutoMapper;
using CentrulMultimedia.Models;
using CentrulMultimedia.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentrulMultimedia
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Film, FilmViewModel>(); //ReverseMap() also a scenario
            CreateMap<Comment, CommentViewModel>();
            CreateMap<Film, FilmsWithCommentsViewModel>();
        }

    }
}
