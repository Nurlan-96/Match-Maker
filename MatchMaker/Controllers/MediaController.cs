using MatchMaker.Application.DTOs;
using MatchMaker.Application.Services.Media;
using MatchMaker.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace MatchMaker.Controllers
{
    [ApiController]
    [Route("api/media")]
    public class MediaController : ControllerBase
    {
        private readonly IMediaProviderFactory _providerFactory;

        public MediaController(IMediaProviderFactory providerFactory)
        {
            _providerFactory = providerFactory;
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<MediaSearchResult>>> Search(
            [FromQuery] string query,
            [FromQuery] MediaCategory category)
        {
            var provider = _providerFactory.GetProvider(category);

            var results = await provider.SearchAsync(query, category);

            return Ok(results);
        }
    }
}