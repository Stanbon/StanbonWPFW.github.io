using Microsoft.EntityFrameworkCore;
using PortfolioApi.Data;
using PortfolioApi.DTOs;
using PortfolioApi.Models;

namespace PortfolioApi.Services;

public class ProjectService(PortfolioDbContext dbContext) : IProjectService
{
    public async Task<IReadOnlyList<ProjectResponseDto>> GetAllAsync() =>
        await dbContext.Projects
            .AsNoTracking()
            .OrderByDescending(project => project.Datum)
            .Select(project => new ProjectResponseDto(
                project.Id,
                project.Titel,
                project.Beschrijving,
                project.Categorie,
                project.Datum))
            .ToListAsync();

    public async Task<ProjectResponseDto?> GetByIdAsync(int id) =>
        await dbContext.Projects
            .AsNoTracking()
            .Where(project => project.Id == id)
            .Select(project => new ProjectResponseDto(
                project.Id,
                project.Titel,
                project.Beschrijving,
                project.Categorie,
                project.Datum))
            .FirstOrDefaultAsync();

    public async Task<ProjectResponseDto> CreateAsync(CreateProjectDto dto)
    {
        var project = new Project
        {
            Titel = dto.Titel,
            Beschrijving = dto.Beschrijving,
            Categorie = dto.Categorie,
            Datum = dto.Datum
        };

        dbContext.Projects.Add(project);
        await dbContext.SaveChangesAsync();

        return ToDto(project);
    }

    public async Task<bool> UpdateAsync(int id, UpdateProjectDto dto)
    {
        var project = await dbContext.Projects.FindAsync(id);

        if (project is null)
            return false;

        project.Titel = dto.Titel;
        project.Beschrijving = dto.Beschrijving;
        project.Categorie = dto.Categorie;
        project.Datum = dto.Datum;

        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var project = await dbContext.Projects.FindAsync(id);

        if (project is null)
            return false;

        dbContext.Projects.Remove(project);
        await dbContext.SaveChangesAsync();
        return true;
    }

    private static ProjectResponseDto ToDto(Project project) =>
        new(project.Id, project.Titel, project.Beschrijving, project.Categorie, project.Datum);
}
