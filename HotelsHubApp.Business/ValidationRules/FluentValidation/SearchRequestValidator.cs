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
        }
    }
}
