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
  
  [HttpGet("debug")]
  public async Task<IActionResult> DebugDatabase()
  {
    var items = await _itemService.GetAllAsync();
    return Ok(new
    {
      Count = items.Count(),
      Items = items
    });
  }

  [HttpPost]
  public async Task<IActionResult> Add([FromBody] ItemCreateDto newItem)
  {
    var createdItem = await _itemService.AddAsync(newItem);
    return CreatedAtAction(nameof(GetAll), new { id = createdItem.Id }, createdItem);
  }
}
