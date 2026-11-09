using PortfolioApi.DTOs;

namespace PortfolioApi.Services;

public interface IProjectService
{
    Task<IReadOnlyList<ProjectResponseDto>> GetAllAsync();
    Task<ProjectResponseDto?> GetByIdAsync(int id);
    Task<ProjectResponseDto> CreateAsync(CreateProjectDto dto);
    Task<bool> UpdateAsync(int id, UpdateProjectDto dto);
    Task<bool> DeleteAsync(int id);
}
