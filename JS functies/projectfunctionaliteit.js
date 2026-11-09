const API_BASE_URL = "https://localhost:5000";

const projectloader = document.querySelector("#projectloader");
const sorteerKeuze = document.querySelector("#sorteer-keuze");
const sorteerRichting = document.querySelector("#sorteer-richting");
let projecten = [];

function escapeHtml(value) {
  const element = document.createElement("div");
  element.textContent = value ?? "";
  return element.innerHTML;
}

function formatteerDatum(datum) {
  return new Intl.DateTimeFormat("nl-NL", {
    year: "numeric",
    month: "long",
    day: "numeric"
  }).format(new Date(`${datum}T00:00:00`));
}

function toonProjecten() {
  const eigenschap = sorteerKeuze.value;
  const richting = sorteerRichting.value === "oplopend" ? 1 : -1;
  const gesorteerd = [...projecten].sort((a, b) => {
    const waardeA = eigenschap === "datum" ? a.datum : a.zelfvoldoening;
    const waardeB = eigenschap === "datum" ? b.datum : b.zelfvoldoening;
    return waardeA < waardeB ? -richting : waardeA > waardeB ? richting : 0;
  });

  projectloader.innerHTML = gesorteerd.map(project => {
    const technieken = project.categorie
      .split(",")
      .map(techniek => `<li>${escapeHtml(techniek.trim())}</li>`)
      .join("");

    return `
      <article class="project" data-datum="${escapeHtml(project.datum)}" data-zelfvoldoening="${project.zelfvoldoening}">
        <img src="${escapeHtml(project.afbeeldingUrl)}" alt="${escapeHtml(project.afbeeldingAlt)}">
        <div>
          <h2>${escapeHtml(project.titel)}</h2>
          <p>${escapeHtml(project.beschrijving)}</p>
          <p>
            <strong>Datum:</strong> ${formatteerDatum(project.datum)}
            · <strong>Zelfvoldoening:</strong> ${project.zelfvoldoening}/5
          </p>
          <h3>Gebruikte technieken</h3>
          <ul>${technieken}</ul>
        </div>
      </article>`;
  }).join("");
}

async function laadProjecten() {
  try {
    const response = await fetch(`${API_BASE_URL}/api/projects`);
    if (!response.ok) throw new Error(`HTTP ${response.status}`);

    projecten = await response.json();
    toonProjecten();
  } catch (error) {
    console.error("Projecten laden mislukt:", error);
    projectloader.innerHTML = "<p>Projecten kunnen niet worden geladen. Controleer of de API online is.</p>";
  }
}

sorteerKeuze.addEventListener("change", toonProjecten);
sorteerRichting.addEventListener("change", toonProjecten);
laadProjecten();
