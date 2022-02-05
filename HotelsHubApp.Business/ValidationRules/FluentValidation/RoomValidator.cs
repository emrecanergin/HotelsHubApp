using FluentValidation;
using HotelsHubApp.Business.BusinessModels.MainModel.messages;

namespace HotelsHubApp.Business.ValidationRules.FluentValidation
{
    public class RoomValidator : AbstractValidator<Room>
    {
        public RoomValidator()
        {
            RuleFor(x => x.rateKey).NotEmpty();
        }
    }
}
