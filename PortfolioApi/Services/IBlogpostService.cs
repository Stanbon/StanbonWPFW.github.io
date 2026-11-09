using PortfolioApi.DTOs;

namespace PortfolioApi.Services;

public interface IBlogpostService
{
    Task<IReadOnlyList<BlogpostResponseDto>> GetAllAsync();
    Task<BlogpostResponseDto?> GetByIdAsync(int id);
    Task<BlogpostResponseDto> CreateAsync(CreateBlogpostDto dto);
    Task<bool> UpdateAsync(int id, UpdateBlogpostDto dto);
    Task<bool> DeleteAsync(int id);
}
