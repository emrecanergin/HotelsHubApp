namespace HotelsHubApp.Business.BusinessModels.HotelbedsModel.model
{
    public class Tax
    {
        public bool included { get; set; }
        public decimal amount { get; set; }
        public string currency { get; set; }
        public string clientAmount { get; set; }
        public string clientCurrency { get; set; }
    }
}
