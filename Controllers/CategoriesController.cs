using Microsoft.AspNetCore.Mvc;
using marketplace.Data.Repositories;
using marketplace.Data.Dtos;
using marketplace.Data.Entities;

namespace marketplace.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoriesRepository _categoriesRepository;
    public CategoriesController(ICategoriesRepository categoriesRepository)
    {
        _categoriesRepository = categoriesRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<CategoryDto>> GetMany()
    {
        var categories = await _categoriesRepository.GetManyAsync();
        return categories.Select(o => new CategoryDto(o.Id, o.Name, o.Description));
    }

    [HttpGet]
    [Route("{categoryId}", Name = "GetCategory")]
    public async Task<ActionResult<CategoryDto>> Get(int categoryId)
    {
        var category = await _categoriesRepository.GetAsync(categoryId);
        // 404
        if (category == null)
            return NotFound();

        return new CategoryDto(category.Id, category.Name, category.Description);
    }

    [HttpPost]
    public async Task<ActionResult<CategoryDto>> Create(CreateCategoryDto createCategoryDto)
    {
        var category = new Category { Name = createCategoryDto.Name, Description = createCategoryDto.Description };

        await _categoriesRepository.CreateAsync(category);

        //201
        return Created("", new CategoryDto(category.Id, category.Name, category.Description));
    }

    [HttpPut]
    [Route("{categoryId}")]
    public async Task<ActionResult<CategoryDto>> Update(int categoryId, UpdateCategoryDto updateCategoryDto)
    {
        var category = await _categoriesRepository.GetAsync(categoryId);
        // 404
        if (category == null)
            return NotFound();

        category.Description = updateCategoryDto.Description;
        await _categoriesRepository.UpdateAsync(category);

        return Ok(new CategoryDto(category.Id, category.Name, category.Description));
    }

    [HttpDelete]
    [Route("{categoryId}", Name = "DeleteCategory")]
    public async Task<ActionResult> Remove(int categoryId)
    {
        var category = await _categoriesRepository.GetAsync(categoryId);
        // 404
        if (category == null)
            return NotFound();

        await _categoriesRepository.DeleteAsync(category);

        //204
        return NoContent();
    }
}
