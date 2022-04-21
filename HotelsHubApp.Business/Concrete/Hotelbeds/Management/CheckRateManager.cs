using AutoMapper;
using HotelsHubApp.Business.Abstract.Hotelbeds.Requests;
using HotelsHubApp.Business.Abstract.Hotelbeds.Services;
using HotelsHubApp.Business.BusinessModels.MainModel.messages;
using HotelsHubApp.Core.Aspects.Autofac.Logging;
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
        //[ValidationAspect(typeof(CheckRateRequestValidator))]
        public async Task<Result<CheckResponse>> CheckRateResponse(CheckRequest request)
        {
            try
            {
                var response = await _checkRateRequest.CheckRate(request);
                
                var res = new CheckResponse();
                res.Currency = response.hotel.currency;
                res.hotel = response.hotel;
                //_mapper.Map(response, res);
                return new Result<CheckResponse>(res, true);

            }
            catch (Exception ex)
            {
                return new Result<CheckResponse>(false, ex.Message);
            }
           //rabbitlog


        }
    }
}
