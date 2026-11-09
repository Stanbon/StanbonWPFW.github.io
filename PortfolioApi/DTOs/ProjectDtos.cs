using System.ComponentModel.DataAnnotations;

namespace PortfolioApi.DTOs;

public record ProjectResponseDto(
    int Id,
    string Titel,
    string Beschrijving,
    string Categorie,
    DateOnly Datum,
    string AfbeeldingUrl,
    string AfbeeldingAlt,
    int Zelfvoldoening);

public class CreateProjectDto
{
    [Required, StringLength(150)]
    public string Titel { get; init; } = string.Empty;

    [Required, StringLength(2000)]
    public string Beschrijving { get; init; } = string.Empty;

    [Required, StringLength(100)]
    public string Categorie { get; init; } = string.Empty;

    public DateOnly Datum { get; init; }

    // Accepteert relatieve paden zoals "images/wavelength.jpg" én volledige https-URL's.
    [Required, StringLength(500)]
    public string AfbeeldingUrl { get; init; } = string.Empty;

    [Required, StringLength(250)]
    public string AfbeeldingAlt { get; init; } = string.Empty;

    [Range(1, 5)]
    public int Zelfvoldoening { get; init; }
}

public class UpdateProjectDto : CreateProjectDto
{
}
