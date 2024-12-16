using InventoryManagementSystem.Core.Entities;
using InventoryManagementSystem.Core.Interfaces;

namespace InventoryManagementSystem.Infrastructure.Repositories
{
    public class InMemoryItemRepository : IItemRepository
    {
        private readonly List<Item> _items = new();

        public Task<IEnumerable<Item>> GetAllAsync() => Task.FromResult(_items.AsEnumerable());

        public Task<Item> GetByIdAsync(Guid id) =>
            Task.FromResult(_items.FirstOrDefault(i => i.Id == id));

        public Task AddAsync(Item item)
        {
            _items.Add(item);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Item item)
        {
            var existingItem = _items.FirstOrDefault(i => i.Id == item.Id);
            if (existingItem != null)
            {
                existingItem.Name = item.Name;
                existingItem.Quantity = item.Quantity;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            _items.RemoveAll(i => i.Id == id);
            return Task.CompletedTask;
        }
    }
}
