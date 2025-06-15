using HotelsHubApp.Business.Abstract.Hotelbeds.Services;
using HotelsHubApp.Business.BusinessModels.MainModel.messages;
using Microsoft.AspNetCore.Mvc;

namespace HotelsHubApp.WebAPI.Controllers
{
    [Route("hotel-api")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;
        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;           
        }

        [Route("hotels")]
        [HttpPost]
        public async Task<IActionResult> Search(SearchRequest searchRequest, [FromQuery] int? page = null, [FromQuery] int? pageSize = null)
        {
            try
            {
                using var cts = new CancellationTokenSource(TimeSpan.FromMinutes(5));
                var response = await _searchService.HotelsResponse(searchRequest);

                if (response.Data.Hotels == null)
                {
                    return NoContent();
                }

                // Pagination parametreleri varsa pagination uygula
                if (page.HasValue || pageSize.HasValue)
                {
                    var currentPage = page ?? 1;
                    var currentPageSize = pageSize ?? 20;
                    
                    // Parametreleri kontrol et
                    if (currentPage < 1) currentPage = 1;
                    if (currentPageSize < 1 || currentPageSize > 100) currentPageSize = 20;

                    // Pagination hesaplamaları
                    var totalItems = response.Data.Hotels.Count;
                    var totalPages = (int)Math.Ceiling((double)totalItems / currentPageSize);
                    var skip = (currentPage - 1) * currentPageSize;
                    var paginatedHotels = response.Data.Hotels.Skip(skip).Take(currentPageSize).ToList();

                    var paginatedResponse = new SearchResponse
                    {
                        SearchId = response.Data.SearchId,
                        Hotels = paginatedHotels,
                        SupplierCommunicationTime = response.Data.SupplierCommunicationTime
                    };

                    return Ok(new ApiResponse<SearchResponse>(paginatedResponse) 
                    { 
                        StatusCode = Response.StatusCode,
                        TotalProcessTime = $"{response.Data.SupplierCommunicationTime}ms",
                        Pagination = new PaginationInfo
                        {
                            CurrentPage = currentPage,
                            PageSize = currentPageSize,
                            TotalItems = totalItems,
                            TotalPages = totalPages,
                            HasNextPage = currentPage < totalPages,
                            HasPreviousPage = currentPage > 1
                        }
                    });
                }

                // Pagination yoksa normal davranış - Swagger UI performansı için 50 ile sınırla
                if (response.Data.Hotels.Count > 50)
                {
                    var limitedHotels = response.Data.Hotels.Take(50).ToList();
                    var limitedResponse = new SearchResponse
                    {
                        SearchId = response.Data.SearchId,
                        Hotels = limitedHotels,
                        SupplierCommunicationTime = response.Data.SupplierCommunicationTime
                    };
                    
                    return Ok(new ApiResponse<SearchResponse>(limitedResponse) 
                    { 
                        StatusCode = Response.StatusCode,
                        TotalProcessTime = $"{response.Data.SupplierCommunicationTime}ms - Limited display",
                        Pagination = new PaginationInfo
                        {
                            CurrentPage = 1,
                            PageSize = 50,
                            TotalItems = response.Data.Hotels.Count,
                            TotalPages = (int)Math.Ceiling((double)response.Data.Hotels.Count / 50),
                            HasNextPage = response.Data.Hotels.Count > 50,
                            HasPreviousPage = false
                        }
                    });
                }

                return Ok(new ApiResponse<SearchResponse>(response.Data) 
                { 
                    StatusCode = Response.StatusCode,
                    TotalProcessTime = $"{response.Data.SupplierCommunicationTime}ms"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { 
                    success = false, 
                    error = ex.Message, 
                    timestamp = DateTime.UtcNow 
                });
            }
        }




    }
}
