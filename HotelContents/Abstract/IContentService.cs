using HotelContents.Models;

namespace HotelContents.Abstract
{
    public interface IContentService
    {
        public Task<ContentRS> GetContent(int from, int to, string destinationCode, string countryCode);

    }
}
