namespace PortfolioApi.Models;

public class Blogpost
{
    public int Id { get; set; }
    public string Titel { get; set; } = string.Empty;
    public string Inhoud { get; set; } = string.Empty;
    public DateOnly Publicatiedatum { get; set; }
}
