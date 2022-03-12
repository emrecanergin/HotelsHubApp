using HotelContents.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelContents.Controllers.Hotelbeds
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IContentService _contentService;
        public ContentController(IContentService contentService)
        {
            _contentService = contentService;    
        }

        [HttpGet]   
        public async Task<IActionResult> ContentInfo(int from, int to, string destinationCode, string countryCode)
        {
            //modelBinding
            var res = await _contentService.GetContent(from, to, destinationCode, countryCode);
            return Ok(res);
        }
    }
}
