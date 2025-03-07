using Microsoft.EntityFrameworkCore;

public class ItemService : IItemService
{
    private readonly DatabaseContext _context;
    
    public ItemService(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Item>> GetAllAsync()
    {
        return await _context.Items.ToListAsync();
    }
    
    public async Task<Item> AddAsync(ItemCreateDto newItem)
    {
        var newItemEntity = new Item
        {
            Name = newItem.Name,
            Count = newItem.Count,
            ExpirationDate = newItem.ExpirationDate,
            ConsumptionRate = newItem.ConsumptionRate
        };
        
        _context.Items.Add(newItemEntity);
        await _context.SaveChangesAsync();
        
        return newItemEntity;
    }

    public async Task<Item> UpdateAsync(int id, ItemCreateDto updatedItem)
    {
        var item = await _context.Items.FindAsync(id);
        
        if (item == null)
        {
            return null;
        }
        
        item.Name = updatedItem.Name;
        item.Count = updatedItem.Count;
        item.ExpirationDate = updatedItem.ExpirationDate;
        item.ConsumptionRate = updatedItem.ConsumptionRate;
        
        await _context.SaveChangesAsync();
        
        return item;
    }
    

    public async Task<bool> DeleteAsync(int id)
    {
        var item = await _context.Items.FindAsync(id);
        
        if (item == null)
        {
            return false;
        }

        _context.Items.Remove(item);
        await _context.SaveChangesAsync();
        return true;
    }
}