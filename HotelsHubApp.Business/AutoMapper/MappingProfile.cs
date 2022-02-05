using AutoMapper;
using HotelsHubApp.Business.BusinessModels.HotelbedsModel.model;
using HotelsHubApp.Business.Helper.ResponseMappping.Models;

namespace HotelsHubApp.Business.AutoMapper
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Hotel, HotelFeatures>();//.ForMember(q => q.categoryCode, opt => opt.MapFrom(s => s.categoryCode));

            CreateMap<HotelFeatures,Hotel>();
        }
    }
}
