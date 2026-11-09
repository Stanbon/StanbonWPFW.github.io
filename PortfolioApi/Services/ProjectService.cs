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
            .Select(project => ToDto(project))
            .ToListAsync();

    public async Task<ProjectResponseDto?> GetByIdAsync(int id)
    {
        var project = await dbContext.Projects.AsNoTracking().FirstOrDefaultAsync(project => project.Id == id);
        return project is null ? null : ToDto(project);
    }

    public async Task<ProjectResponseDto> CreateAsync(CreateProjectDto dto)
    {
        var project = new Project
        {
            Titel = dto.Titel,
            Beschrijving = dto.Beschrijving,
            Categorie = dto.Categorie,
            Datum = dto.Datum,
            AfbeeldingUrl = dto.AfbeeldingUrl,
            AfbeeldingAlt = dto.AfbeeldingAlt,
            Zelfvoldoening = dto.Zelfvoldoening
        };

        dbContext.Projects.Add(project);
        await dbContext.SaveChangesAsync();
        return ToDto(project);
    }

    public async Task<bool> UpdateAsync(int id, UpdateProjectDto dto)
    {
        var project = await dbContext.Projects.FindAsync(id);
        if (project is null) return false;

        project.Titel = dto.Titel;
        project.Beschrijving = dto.Beschrijving;
        project.Categorie = dto.Categorie;
        project.Datum = dto.Datum;
        project.AfbeeldingUrl = dto.AfbeeldingUrl;
        project.AfbeeldingAlt = dto.AfbeeldingAlt;
        project.Zelfvoldoening = dto.Zelfvoldoening;
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var project = await dbContext.Projects.FindAsync(id);
        if (project is null) return false;

        dbContext.Projects.Remove(project);
        await dbContext.SaveChangesAsync();
        return true;
    }

    private static ProjectResponseDto ToDto(Project project) =>
        new(
            project.Id,
            project.Titel,
            project.Beschrijving,
            project.Categorie,
            project.Datum,
            project.AfbeeldingUrl,
            project.AfbeeldingAlt,
            project.Zelfvoldoening);
}
