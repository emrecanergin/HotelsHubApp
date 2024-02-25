using AutoMapper;
using HotelsHubApp.Business.Abstract.Hotelbeds.Requests;
using HotelsHubApp.Business.Abstract.Hotelbeds.Services;
using HotelsHubApp.Business.BusinessModels.MainModel.messages;
using HotelsHubApp.Business.ValidationRules.FluentValidation;
using HotelsHubApp.Core.Aspects.Autofac.Logging;
using HotelsHubApp.Core.Aspects.Autofac.Validation;
using HotelsHubApp.Core.Utilities.Results;

namespace HotelsHubApp.Business.Concrete.Hotelbeds.Management
{
    public class CheckRateManager : ICheckRateService
    {
        private readonly ICheckRateRequest _checkRateRequest;
        private readonly IMapper _mapper;
        public CheckRateManager(ICheckRateRequest checkRateRequest,IMapper mapper)
        {
            _checkRateRequest = checkRateRequest;
            _mapper = mapper;   
        }
        
        
        [LogAspect]
        [ValidationAspect(typeof(CheckRateRequestValidator))]
        public async Task<Result<CheckResponse>> CheckRateResponse(CheckRequest request)
        {
            var response = await _checkRateRequest.CheckRate(request);
            var res = new CheckResponse();
            res.Currency = response.hotel.currency;
            res.hotel = response.hotel;
            return new Result<CheckResponse>(res);
            //rabbitlog
        }
    }
}
