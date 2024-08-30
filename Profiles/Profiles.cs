using AutoMapper;
using CIE.WebApp.Data;
using CIE.WebApp.Models.Request;
using CIE.WebApp.Models.Response;
using CIE.WebApp.Models.ViewModels;

namespace CIE.WebApp.Profiles
{
    public class Profiles: Profile
    {

        public Profiles()
        {
            CreateMap<Cie10, Cie10ResponseDto>().ReverseMap();
            CreateMap<Cie10RequestDto ,Cie10>();
            CreateMap<Cie10ResponseDto, Cie10ViewModel>().ReverseMap();
            CreateMap<Cie10ResponseDto ,Cie10SearchModel>().ReverseMap();
            CreateMap<Cie10ViewModel, Cie10SearchModel>().ReverseMap();

        }
    }
}
