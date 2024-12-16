using InventoryManagementSystem.Core.Entities;
using InventoryManagementSystem.Core.Interfaces;
using InventoryManagementSystem.Application.DTOs;

namespace InventoryManagementSystem.Application.Services
{
    public class ItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<IEnumerable<ItemDto>> GetItemsAsync()
        {
            var items = await _itemRepository.GetAllAsync();
            return items.Select(i => new ItemDto
            {
                Id = i.Id,
                Name = i.Name,
                Quantity = i.Quantity
            });
        }

        public async Task AddItemAsync(ItemDto itemDto)
        {
            var item = new Item
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Quantity = itemDto.Quantity
            };
            await _itemRepository.AddAsync(item);
        }
    }
}
