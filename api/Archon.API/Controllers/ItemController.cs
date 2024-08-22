using Archon.API.CustomActionFilters;
using Archon.API.Models.Domain;
using Archon.API.Models.DTO;
using Archon.API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Archon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IItemRepository itemRepository;

        public ItemController(IMapper mapper, IItemRepository itemRepository)
        {
            this.mapper = mapper;
            this.itemRepository = itemRepository;
        }

        //Method for receiving all items from database
        [HttpGet]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAllItems([FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize=50)
        {
            //receiving list of Domain Items
            var itemsDomainModel = await itemRepository.GetAllAsync(filterQuery,sortBy,isAscending ?? true,pageNumber,pageSize);

            //Mapping to ResponseItemDto using AutoMapper
            return Ok(mapper.Map<List<ResponseItemDto>>(itemsDomainModel));
        }

        //Method for receiving single item with id
        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetItemById([FromRoute] Guid id)
        {
            var itemDomainModel = await itemRepository.GetByIdAsync(id);
            //in case item with given ID wasn't found
            if (itemDomainModel == null)
            {
                return NotFound();
            }  
            return Ok(mapper.Map<ResponseItemDto>(itemDomainModel));
        }

        //Method for creating new item
        [HttpPost]
        [ValidateModel]//using custom validation
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateItem([FromBody] CreateItemDto createItemDto)
        {
            var itemDomainModel = mapper.Map<Item>(createItemDto);
            await itemRepository.CreateAsync(itemDomainModel);
            return Ok(mapper.Map<ResponseItemDto>(itemDomainModel));
        }

        //Method for Updating existing item
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel] //using custom validation
        [Authorize(Roles = "Writer, Reader")]
        public async Task<IActionResult> UpdateItem([FromRoute] Guid id, [FromBody] CreateItemDto updateItemDto)
        {
            var itemDomainModel = mapper.Map<Item>(updateItemDto);
            itemDomainModel = await itemRepository.UpdateAsync(id,itemDomainModel);
            if(itemDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<ResponseItemDto>(itemDomainModel));
        }

        //Method for Deleting existing item
        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer, Reader")]
        public async Task<IActionResult> DeleteItem([FromRoute] Guid id)
        {
            var itemDomainModel = await itemRepository.DeleteAsync(id);
            if(itemDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<ResponseItemDto>(itemDomainModel));
        }
    }
}
