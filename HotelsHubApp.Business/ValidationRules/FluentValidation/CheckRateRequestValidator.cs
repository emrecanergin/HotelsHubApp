using FluentValidation;
using HotelsHubApp.Business.BusinessModels.MainModel.messages;

namespace HotelsHubApp.Business.ValidationRules.FluentValidation
{
    public class CheckRateRequestValidator : AbstractValidator<CheckRequest>
    {
        public CheckRateRequestValidator()
        {
            RuleFor(x => x.rooms).NotEmpty().SetValidator(new RoomValidator());        
        }
    }
  
}
