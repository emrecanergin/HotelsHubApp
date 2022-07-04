namespace HotelsHubApp.Business.BusinessModels.MainModel.model
{
    public class ResponseRoom
    {
        public string RoomName { get; set; }
        public string BoardMainName { get; set; }
        public string Currency { get; set; }
        public decimal Price { get; set; }
        public bool Refundable { get; set; }
        public string RoomCode { get; set; }
        public string BoardMainCode { get; set; }
        public bool CommissionPrice { get; set; }
        public string PaymentType { get; set; }
        public int RoomIndex { get; set; }
        public bool OnRequest { get; set; }
    }
}
