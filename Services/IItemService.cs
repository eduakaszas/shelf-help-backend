public interface IItemService
{
  Task<IEnumerable<Item>> GetAllAsync();
  Task<Item> AddAsync(ItemCreateDto newItem);
  Task<bool> DeleteAsync(int id); 
  Task<Item> UpdateAsync(int id, ItemCreateDto updatedItem);
}