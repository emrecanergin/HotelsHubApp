namespace HotelContents.Models
{
    public class RoomFacility
    {
        public int facilityCode { get; set; }
        public int facilityGroupCode { get; set; }
        public bool indFee { get; set; }
        public bool indYesOrNo { get; set; }
        public bool voucher { get; set; }
        public bool? indLogic { get; set; }
        public int? number { get; set; }
    }
}
