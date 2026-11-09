using Microsoft.EntityFrameworkCore;
using PortfolioApi.Data;
using PortfolioApi.DTOs;
using PortfolioApi.Models;

namespace PortfolioApi.Services;

public class BlogpostService(PortfolioDbContext dbContext) : IBlogpostService
{
    public async Task<IReadOnlyList<BlogpostResponseDto>> GetAllAsync() =>
        await dbContext.Blogposts
            .AsNoTracking()
            .OrderByDescending(blogpost => blogpost.Publicatiedatum)
            .Select(blogpost => new BlogpostResponseDto(
                blogpost.Id,
                blogpost.Titel,
                blogpost.Inhoud,
                blogpost.Publicatiedatum))
            .ToListAsync();

    public async Task<BlogpostResponseDto?> GetByIdAsync(int id) =>
        await dbContext.Blogposts
            .AsNoTracking()
            .Where(blogpost => blogpost.Id == id)
            .Select(blogpost => new BlogpostResponseDto(
                blogpost.Id,
                blogpost.Titel,
                blogpost.Inhoud,
                blogpost.Publicatiedatum))
            .FirstOrDefaultAsync();

    public async Task<BlogpostResponseDto> CreateAsync(CreateBlogpostDto dto)
    {
        var blogpost = new Blogpost
        {
            Titel = dto.Titel,
            Inhoud = dto.Inhoud,
            Publicatiedatum = dto.Publicatiedatum
        };

        dbContext.Blogposts.Add(blogpost);
        await dbContext.SaveChangesAsync();

        return ToDto(blogpost);
    }

    public async Task<bool> UpdateAsync(int id, UpdateBlogpostDto dto)
    {
        var blogpost = await dbContext.Blogposts.FindAsync(id);

        if (blogpost is null)
            return false;

        blogpost.Titel = dto.Titel;
        blogpost.Inhoud = dto.Inhoud;
        blogpost.Publicatiedatum = dto.Publicatiedatum;

        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var blogpost = await dbContext.Blogposts.FindAsync(id);

        if (blogpost is null)
            return false;

        dbContext.Blogposts.Remove(blogpost);
        await dbContext.SaveChangesAsync();
        return true;
    }

    private static BlogpostResponseDto ToDto(Blogpost blogpost) =>
        new(blogpost.Id, blogpost.Titel, blogpost.Inhoud, blogpost.Publicatiedatum);
}
