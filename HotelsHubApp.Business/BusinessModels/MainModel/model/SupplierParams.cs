namespace HotelsHubApp.Business.BusinessModels.MainModel.bookingModel
{
    public class SupplierParams
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string SearchUrl { get; set; }
        public string ValuationUrl { get; set; }
        public string ConfirmationUrl { get; set; }
        public string CommonUrl { get; set; }
        public object AdditionalParameters { get; set; }
    }
}
