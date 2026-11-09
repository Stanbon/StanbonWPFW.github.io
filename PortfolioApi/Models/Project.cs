namespace PortfolioApi.Models;

public class Project
{
    public int Id { get; set; }
    public string Titel { get; set; } = string.Empty;
    public string Beschrijving { get; set; } = string.Empty;
    public string Categorie { get; set; } = string.Empty;
    public DateOnly Datum { get; set; }
    public string AfbeeldingUrl { get; set; } = string.Empty;
    public string AfbeeldingAlt { get; set; } = string.Empty;
    public int Zelfvoldoening { get; set; }
}
