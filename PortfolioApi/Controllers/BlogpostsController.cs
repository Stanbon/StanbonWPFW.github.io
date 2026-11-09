using Microsoft.AspNetCore.Mvc;
using PortfolioApi.DTOs;
using PortfolioApi.Services;

namespace PortfolioApi.Controllers;

[ApiController]
[Route("api/blogposts")]
public class BlogpostsController(IBlogpostService blogpostService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<BlogpostResponseDto>>> GetAll() =>
        Ok(await blogpostService.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<BlogpostResponseDto>> GetById(int id)
    {
        var blogpost = await blogpostService.GetByIdAsync(id);
        return blogpost is null ? NotFound() : Ok(blogpost);
    }

    [HttpPost]
    public async Task<ActionResult<BlogpostResponseDto>> Create(CreateBlogpostDto dto)
    {
        var blogpost = await blogpostService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = blogpost.Id }, blogpost);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateBlogpostDto dto) =>
        await blogpostService.UpdateAsync(id, dto) ? NoContent() : NotFound();

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) =>
        await blogpostService.DeleteAsync(id) ? NoContent() : NotFound();
}
