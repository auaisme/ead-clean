namespace InventoryManagementSystem.Core.Entities
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}