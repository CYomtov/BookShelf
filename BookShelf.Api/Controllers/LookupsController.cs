using BookShelf.Application.DTOs;
using BookShelf.Application.Interfaces;
using BookShelf.Infrastructure.Books;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShelf.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupsController : ControllerBase
    {
        private readonly ILogger<LookupsController> _logger;
        private readonly ILookupRepository _lookupRepository;
        public LookupsController(ILogger<LookupsController> logger, ILookupRepository lookupRepository)
        {
            _logger = logger;
            _lookupRepository = lookupRepository;
        }

        [HttpGet("statuses")]
        public async Task<ActionResult<IEnumerable<StatusDto>>> GetStatuses()
        {
            _logger.LogInformation("Fetching book statuses");
            var statuses = await _lookupRepository.GetBookStatusAsync();
            return Ok(statuses);
        }

        [HttpGet("Genres")]
        public async Task<ActionResult<IEnumerable<GenreDto>>> GetGenres()
        {
            _logger.LogInformation("Fetching book genres");
            var genres = await _lookupRepository.GetAllGenresAsync();
            return Ok(genres);
        }

    }
}
