public class ItemService : IItemService
{
    private readonly List<Item> _items = new(); // Temporary storage

    public async Task<IEnumerable<Item>> GetAllAsync()
    {
        return await Task.FromResult(_items);
    }

    public async Task<Item> AddAsync(ItemCreateDto newItem)
    {
        var newItemEntity = new Item
        {
            Id = _items.Count + 1, // Auto-increment ID
            Name = newItem.Name,
            Count = newItem.Count,
            ExpirationDate = newItem.ExpirationDate,
            ConsumptionRate = newItem.ConsumptionRate
        };

        _items.Add(newItemEntity);
        return await Task.FromResult(newItemEntity);
    }
}