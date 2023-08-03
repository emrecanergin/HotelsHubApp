namespace HotelsHubApp.Business.BusinessModels.MainModel.model
{
    public class Rate
    {
        public decimal Price { get; set; }
        public string MinimumSellingPrice { get; set; }
        public string Currency { get; set; }
        public string BoardCode { get; set; }
        public string BoardName { get; set; }
        public int Rooms { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public string Amount { get; set; }
    }
}
