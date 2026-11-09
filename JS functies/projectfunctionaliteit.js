const API_BASE_URL = "https://YOUR-API-URL.azurewebsites.net";
const projectloader = document.querySelector("#projectloader");
const projectStatus = document.querySelector("#project-status");
const sorteerKeuze = document.querySelector("#sorteer-keuze");
const sorteerRichting = document.querySelector("#sorteer-richting");

let projecten = [];

function formatteerDatum(datum) {
  return new Intl.DateTimeFormat("nl-NL", {
    day: "2-digit",
    month: "long",
    year: "numeric"
  }).format(new Date(`${datum}T00:00:00`));
}

function toonProjecten() {
  const eigenschap = sorteerKeuze.value;
  const richting = sorteerRichting.value === "oplopend" ? 1 : -1;

  const gesorteerdeProjecten = [...projecten].sort((a, b) => {
    const waardeA = String(a[eigenschap]).toLocaleLowerCase("nl");
    const waardeB = String(b[eigenschap]).toLocaleLowerCase("nl");
    return waardeA.localeCompare(waardeB, "nl") * richting;
  });

  projectloader.replaceChildren();

  for (const project of gesorteerdeProjecten) {
    const artikel = document.createElement("article");
    artikel.className = "project";

    const inhoud = document.createElement("div");
    const titel = document.createElement("h2");
    titel.textContent = project.titel;

    const beschrijving = document.createElement("p");
    beschrijving.textContent = project.beschrijving;

    const details = document.createElement("p");
    const categorie = document.createElement("strong");
    categorie.textContent = "Categorie:";
    details.append(categorie, ` ${project.categorie} · `);

    const datumLabel = document.createElement("strong");
    datumLabel.textContent = "Datum:";
    details.append(datumLabel, ` ${formatteerDatum(project.datum)}`);

    inhoud.append(titel, beschrijving, details);
    artikel.append(inhoud);
    projectloader.append(artikel);
  }
}

async function laadProjecten() {
  try {
    const response = await fetch(`${API_BASE_URL}/api/projects`);

    if (!response.ok) {
      throw new Error(`API gaf status ${response.status}`);
    }

    projecten = await response.json();
    projectStatus.hidden = true;
    toonProjecten();
  } catch (error) {
    console.error(error);
    projectStatus.textContent =
      "Projecten kunnen niet worden geladen. Controleer of de API online is.";
  }
}

sorteerKeuze.addEventListener("change", toonProjecten);
sorteerRichting.addEventListener("change", toonProjecten);

laadProjecten();
