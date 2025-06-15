using FluentValidation;
using HotelsHubApp.Business.BusinessModels.MainModel.messages;

namespace HotelsHubApp.Business.ValidationRules.FluentValidation
{
    public class SearchRequestValidator : AbstractValidator<SearchRequest>
    {
        public SearchRequestValidator()
        {
            RuleFor(x => x.CheckIn).NotEmpty().GreaterThanOrEqualTo(DateTime.Now.Date);
            RuleFor(x => x.CheckOut).NotEmpty().LessThanOrEqualTo(DateTime.Now.Date.AddYears(1)).GreaterThanOrEqualTo(DateTime.Now.Date);
            RuleFor(x => x.Settings.Rooms).NotEmpty();
            
            // DestinationCode VEYA HotelCodes'dan en az biri dolu olmalı
            RuleFor(x => x.Settings)
                .Must(x => (x.DestinationCode != null && !string.IsNullOrEmpty(x.DestinationCode.Code)) || 
                          (x.HotelCodes != null && x.HotelCodes.Any()))
                .WithMessage("Either DestinationCode or HotelCodes must be provided");
        }
    }
}
