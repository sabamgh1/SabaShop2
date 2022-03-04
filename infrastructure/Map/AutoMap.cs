using System;
using AutoMapper;
using core.Domain;
using infrastructure.Data.Entities;

namespace infrastructure.Map
{
    public class AutoMap:Profile
    {
        public AutoMap()
        {
            CreateMap<MCategory,Category>().ReverseMap();
            CreateMap<MProduct,Product>().ReverseMap();
            CreateMap<MColor,Color>().ReverseMap();
            CreateMap<MSlider,Slider>().ReverseMap();
            CreateMap<MBaner,Baner>().ReverseMap();
             CreateMap<MUser,User>().ReverseMap();
        }
    }
}