using Microsoft.AspNetCore.Mvc;

[Route("api/items")]
[ApiController]
public class ItemsController : ControllerBase
{
  private readonly IItemService _itemService;
  public ItemsController(IItemService itemService)
  {
    _itemService = itemService;
  }

  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    var items = await _itemService.GetAllAsync();
    return Ok(items);
  }
  
  [HttpPost]
  public async Task<IActionResult> Add([FromBody] ItemCreateDto newItem)
  {
    var createdItem = await _itemService.AddAsync(newItem);
    return CreatedAtAction(nameof(GetAll), new { id = createdItem.Id }, createdItem);
  }
  
  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)  // or Guid id, depending on your ID type
  {
    var result = await _itemService.DeleteAsync(id);
    
    if (!result)
    {
      return NotFound();
    }
    
    return NoContent();
  }
  
  [HttpPut("{id}")]
  public async Task<IActionResult> Update(int id, [FromBody] ItemCreateDto updatedItem)
  {
    var result = await _itemService.UpdateAsync(id, updatedItem);
    
    if (result == null)
    {
      return NotFound();
    }
    
    return Ok(result);
  }
}
