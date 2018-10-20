using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventCatalogAPI.Data;
using EventCatalogAPI.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EventCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : Controller
    {
        private readonly CatalogContext _catalogContext;
        private readonly IConfiguration _configuration;

    public CatalogController(CatalogContext catalogContext, IConfiguration configuration)
        {

            _catalogContext = catalogContext;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventOccassions()
        {
            var items = await _catalogContext.EventOccasions.ToListAsync();
            return Ok(items);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventLocations()
        {
            var items = await _catalogContext.EventLocations.ToListAsync();
            return Ok(items);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventCategories()
        {
            var items = await _catalogContext.EventCategories.ToListAsync();
            return Ok(items);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Items(
            [FromQuery] int pageSize = 6,
            [FromQuery] int pageIndex = 0
            )
        {

            var totalItems = await
                  _catalogContext.EventItems.LongCountAsync();

            var itemsOnPage = await _catalogContext.EventItems
                 .OrderBy(c => c.Name)
                 .Skip(pageIndex * pageSize)
                 .Take(pageSize)
                 .ToListAsync();

            itemsOnPage = ChangeUrlPlaceholder(itemsOnPage);
            return Ok(itemsOnPage);
        }

        
        [HttpGet]
        [Route("[action]/withname/{name:minlength(1)}")]
        public async Task<IActionResult> Items(
            string name,
            [FromQuery] int pageSize = 6,
            [FromQuery] int pageIndex = 0
            )
        {

            var totalItems = await
                  _catalogContext.EventItems
                  .Where(c => c.Name.StartsWith(name))
                  .LongCountAsync();

            var itemsOnPage = await _catalogContext.EventItems
                .Where(c => c.Name.StartsWith(name))
                 .OrderBy(c => c.Name)
                 .Skip(pageIndex * pageSize)
                 .Take(pageSize)
                 .ToListAsync();

            itemsOnPage = ChangeUrlPlaceholder(itemsOnPage);
            return Ok(itemsOnPage);
        }

        [HttpGet]
        [Route("items/{id:int}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var item = await _catalogContext.EventItems
                     .SingleOrDefaultAsync(c => c.Id == id);

            if (item != null)
            {
                item.PictureUrl = item.PictureUrl.Replace("http://externalcatalogbaseurltobereplaced",
                                _configuration["ExternalCatalogBaseUrl"]
                                );

                return Ok(item);
            }
            return NotFound();
        }

        private List<EventItem> ChangeUrlPlaceholder
            (List<EventItem> items)
        {
            items.ForEach(
                x => x.PictureUrl =
                x.PictureUrl.Replace("http://externalcatalogbaseurltobereplaced",
                                _configuration["ExternalCatalogBaseUrl"]
                                ));
            return items;
        }
    }
}