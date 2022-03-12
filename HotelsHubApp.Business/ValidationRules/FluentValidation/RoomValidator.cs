using FluentValidation;
using HotelsHubApp.Business.BusinessModels.HotelbedsModel.model;

namespace HotelsHubApp.Business.ValidationRules.FluentValidation
{
    public class RoomValidator : AbstractValidator<CheckRateRoom>
    {
        public RoomValidator()
        {
            RuleFor(x => x.rateKey).NotEmpty();
        }
    }
}
