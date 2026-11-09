using System.ComponentModel.DataAnnotations;

namespace PortfolioApi.DTOs;

public record ProjectResponseDto(
    int Id,
    string Titel,
    string Beschrijving,
    string Categorie,
    DateOnly Datum);

public class CreateProjectDto
{
    [Required, StringLength(150)]
    public string Titel { get; init; } = string.Empty;

    [Required, StringLength(2000)]
    public string Beschrijving { get; init; } = string.Empty;

    [Required, StringLength(100)]
    public string Categorie { get; init; } = string.Empty;

    public DateOnly Datum { get; init; }
}

public class UpdateProjectDto : CreateProjectDto
{
}
