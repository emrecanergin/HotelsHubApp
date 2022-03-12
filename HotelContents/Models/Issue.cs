namespace HotelContents.Models
{
    public class Issue
    {
        public string issueCode { get; set; }
        public string issueType { get; set; }
        public string dateFrom { get; set; }
        public string dateTo { get; set; }
        public int order { get; set; }
        public bool alternative { get; set; }
    }

}
