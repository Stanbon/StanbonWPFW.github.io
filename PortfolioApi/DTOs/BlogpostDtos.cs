using System.ComponentModel.DataAnnotations;

namespace PortfolioApi.DTOs;

public record BlogpostResponseDto(
    int Id,
    string Titel,
    string Inhoud,
    DateOnly Publicatiedatum);

public class CreateBlogpostDto
{
    [Required, StringLength(200)]
    public string Titel { get; init; } = string.Empty;

    [Required, StringLength(10000)]
    public string Inhoud { get; init; } = string.Empty;

    public DateOnly Publicatiedatum { get; init; }
}

public class UpdateBlogpostDto : CreateBlogpostDto
{
}
