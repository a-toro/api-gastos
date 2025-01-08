using ApiGastos.Dtos;
using ApiGastos.Entities;
using ApiGastos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiGastos.Controllers;

// Exmaple -> http://localhost:5001/IncomesCategory 
[ApiController]
[Route("IncomesCategory")]
public class IncomesCategoryController : ControllerBase
{

    private readonly IRepository<IncomeCategory> itemsRepository;

    public IncomesCategoryController(IRepository<IncomeCategory> itemsRepository)
    {
        this.itemsRepository = itemsRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<CategoryDto>> GetAsync()
    {
        var items = (await itemsRepository.GetAllAsync()).Select(item => item.AsDto());
        return items;
    }

    // GET /items/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDto>> GetByIdAsync(Guid id)
    {
        // var item = items.Where(item => item.Id == id).SingleOrDefault();
        var item = await itemsRepository.GetAsync(id);

        if (item == null)
        {
            return NotFound();
        }
        return item.AsDto();

    }

    // POST /items
    [HttpPost]
    public async Task<ActionResult<CategoryDto>> PostAsync(CreateCategoryDto createItemDto)
    {
        var item = new IncomeCategory
        {
            Name = createItemDto.Name,
            Description = createItemDto.Description,
            CreatedDate = DateTimeOffset.UtcNow,
        };

        await itemsRepository.CreateAsync(item);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = item.Id }, item);
    }
    // PUT /items/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(Guid id, UpdateCategoryDto updateItemDto)
    {
        var existingItem = await itemsRepository.GetAsync(id);

        if (existingItem == null)
        {
            return NotFound();
        }

        existingItem.Name = updateItemDto.Name;
        existingItem.Description = updateItemDto.Description;

        await itemsRepository.UpdatedAsync(existingItem);

        return NoContent();
    }

    // DELETE /items/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var existingItem = await itemsRepository.GetAsync(id);

        if (existingItem == null)
        {
            return NotFound();
        }

        await itemsRepository.RemoveAsync(id);

        return NoContent();

    }
}