using Microsoft.AspNetCore.Mvc;
using marketplace.Data.Dtos;
using marketplace.Data.Entities;
using marketplace.Data.Repositories;

namespace marketplace.Controllers;

[ApiController]
[Route("api/categories/{categoryId}/ads")]
public class AdsController : ControllerBase
{
    private readonly ICategoriesRepository _categoriesRepository;
    private readonly IAdsRepository _adsRepository;
    public AdsController(ICategoriesRepository categoriesRepository, IAdsRepository adsRepository)
    {
        _categoriesRepository = categoriesRepository;
        _adsRepository = adsRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<AdDto>> GetMany(int categoryId)
    {
        var ads = await _adsRepository.GetManyAsync(categoryId);
        return ads.Select(o => new AdDto(o.Id, o.Name, o.Description));
    }

    [HttpGet]
    [Route("{adId}")]
    public async Task<ActionResult<AdDto>> Get(int categoryId, int adId)
    {
        var ad = await _adsRepository.GetAsync(categoryId, adId);
        // 404
        if (ad == null)
            return NotFound();

        return Ok(new AdDto(ad.Id, ad.Name, ad.Description));
    }

    [HttpPost]
    public async Task<ActionResult<AdDto>> Create(int categoryId, CreateAdDto createAdDto)
    {
        var category = await _categoriesRepository.GetAsync(categoryId);
        if (category == null) return NotFound($"Couldn't find a category with id of {categoryId}");

        var ad = new Ad { Name = createAdDto.Name, Description = createAdDto.Description };
        ad.CategoryId = categoryId;

        await _adsRepository.CreateAsync(ad);

        return Created("", new AdDto(ad.Id, ad.Name, ad.Description));
    }

    [HttpPut]
    [Route("{adId}")]
    public async Task<ActionResult<AdDto>> Update(int categoryId, int adId, UpdateAdDto updateAdDto)
    {
        var category = await _categoriesRepository.GetAsync(categoryId);
        // 404
        if (category == null)
            return NotFound($"Couldn't find a category with id of {categoryId}");

        var ad = await _adsRepository.GetAsync(categoryId, adId);
        // 404
        if (ad == null)
            return NotFound();

        ad.Description = updateAdDto.Description;
        await _adsRepository.UpdateAsync(ad);

        return Ok(new AdDto(ad.Id, ad.Name, ad.Description));
    }

    [HttpDelete]
    [Route("{adId}")]
    public async Task<ActionResult> Remove(int categoryId, int adId)
    {
        var ad = await _adsRepository.GetAsync(categoryId, adId);
        // 404
        if (ad == null)
            return NotFound();

        await _adsRepository.DeleteAsync(ad);

        //204
        return NoContent();
    }
}