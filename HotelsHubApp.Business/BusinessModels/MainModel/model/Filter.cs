namespace HotelsHubApp.Business.BusinessModels.MainModel.model
{
    public class Filter
    {
        public HotelFilter HotelFilter { get; set; }
        public bool Policy { get; set; }
        public bool PriceBreakdown { get; set; }
        public bool Promotions { get; set; }
        public bool TaxesAndFees { get; set; }
        public bool BedOptions { get; set; }
        public bool RoomFeatures { get; set; }
        public bool FreeExtras { get; set; }
        public bool RoomImportantNote { get; set; }
    }
}
