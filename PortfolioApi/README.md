# Portfolio API

ASP.NET Core Web API (.NET 10) voor Projecten en Blogposts.

## Mapstructuur

```text
PortfolioApi/
├── Controllers/
├── Data/
├── DTOs/
├── Models/
├── Services/
├── Program.cs
├── appsettings.json
└── PortfolioApi.csproj
```

## Database

De API gebruikt SQL Server LocalDB met EF Core. Bij het opstarten wordt
`Database.EnsureCreated()` uitgevoerd. Daardoor wordt de database automatisch
aangemaakt als deze nog niet bestaat en blijven gegevens bewaard na een herstart.

Pas eventueel de connection string `PortfolioDatabase` in `appsettings.json` aan
als je een andere SQL Server-instance gebruikt.

## Starten

```bash
dotnet restore
dotnet run
```

Swagger UI is beschikbaar op `/swagger`.

## Endpoints

- `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}`
- `/api/projects`
- `/api/blogposts`
