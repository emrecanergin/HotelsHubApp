namespace HotelsHubApp.Business.BusinessModels.MainModel.model
{
    public class TaxesAndFee
    {
        public bool IncludedPrice { get; set; }
        public string Description { get; set; }
        public bool Mandotary { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public bool Bar { get; set; }
        public double CommissionPrice { get; set; }
    }
}
