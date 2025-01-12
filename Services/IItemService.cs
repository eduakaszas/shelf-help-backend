public interface IItemService
{
  Task<IEnumerable<Item>> GetAllAsync();
  Task<Item> AddAsync(ItemCreateDto newItem);
}