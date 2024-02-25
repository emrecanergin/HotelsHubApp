namespace HotelsHubApp.Business.BusinessModels.MainModel.model
{
    public class Policy
    {
        public decimal Price { get; set; }
        public MinimumSalePrice MinimumSalePrice { get; set; }
        public string Currency { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public byte PolicyType { get; set; }
    }
}
