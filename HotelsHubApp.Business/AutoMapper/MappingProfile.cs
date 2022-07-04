using AutoMapper;
using HotelsHubApp.Business.BusinessModels.HotelbedsModel.messages;
using HotelsHubApp.Business.BusinessModels.HotelbedsModel.model;
using HotelsHubApp.Business.BusinessModels.MainModel.messages;
using HotelsHubApp.Business.BusinessModels.MainModel.model;
using HotelsHubApp.Business.Helper.ResponseMappping.Models;

namespace HotelsHubApp.Business.AutoMapper
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BusinessModels.HotelbedsModel.model.Hotel, HotelFeatures>();

            CreateMap<HotelFeatures, BusinessModels.HotelbedsModel.model.Hotel>();

            CreateMap<PaymentCard, CreditCard>();

            CreateMap<CreditCard, PaymentCard>();

            CreateMap<ResponseRoom, Helper.ResponseMappping.Models.Room>();
            CreateMap<Helper.ResponseMappping.Models.Room, ResponseRoom>()
                .ForMember(d => d.PaymentType, m => m.MapFrom(s => s.rate.paymentType))
                .ForMember(d => d.BoardMainCode, m => m.MapFrom(s => s.rate.boardCode))
                .ForMember(d => d.BoardMainName, m => m.MapFrom(s => s.rate.boardName))
                .ForMember(d => d.RoomIndex, m => m.MapFrom(s => s.rate.rooms))
                .ForMember(d => d.Price, m => m.MapFrom(s => s.rate.net))
                .ForMember(d => d.RoomCode, m => Guid.NewGuid().ToString())
                .ForMember(d => d.RoomName, m => m.MapFrom(s => s.roomname));
        }
    }
}
