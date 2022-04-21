using AutoMapper;
using HotelsHubApp.Business.BusinessModels.HotelbedsModel.messages;
using HotelsHubApp.Business.BusinessModels.HotelbedsModel.model;
using HotelsHubApp.Business.BusinessModels.MainModel.messages;
using HotelsHubApp.Business.BusinessModels.MainModel.model;
using HotelsHubApp.Business.Helper.ResponseMappping.Models;
using Rate = HotelsHubApp.Business.BusinessModels.HotelbedsModel.model.Rate;

namespace HotelsHubApp.Business.AutoMapper
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BusinessModels.HotelbedsModel.model.Hotel, HotelFeatures>();//.ForMember(q => q.categoryCode, opt => opt.MapFrom(s => s.categoryCode));

            CreateMap<HotelFeatures, BusinessModels.HotelbedsModel.model.Hotel>();

            CreateMap<CheckResponse, CheckRateRS>();
            
            CreateMap<CheckRateRS, CheckResponse>();

            //example
            //CreateMap<CreditCard, PaymentCard>().ForMember(a => a.cardType, b => b.MapFrom(c => c.CardType));
            
            CreateMap<PaymentCard, CreditCard>();           
        }
    }
}
