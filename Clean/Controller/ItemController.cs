using InventoryManagementSystem.Application.DTOs;
using InventoryManagementSystem.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly ItemService _itemService;

        public ItemsController(ItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var items = await _itemService.GetItemsAsync();
            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] ItemDto itemDto)
        {
            await _itemService.AddItemAsync(itemDto);
            return CreatedAtAction(nameof(GetItems), null);
        }
    }
}
