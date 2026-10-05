/* array + plaatsen*/
const projecten = [
  {
    naam: "Autohome",
    datum: "2024-01",
    zelfvoldoening: 2,
    afbeelding: {
      src: "images/autohome.jpg",
      alt: "Logo van AutoHome met een Raspberry Pi en een temperatuursensor.",
    },
    beschrijving: [
      "Autohome was mijn eerste project tijdens Software Engineering.",
	  "Met mijn projectgroep heb ik een simpele home-assistant-fork gemaakt op een Raspberry Pi.",
      "Een lichtsensor leest de lichtniveaus. Daarna kunnen de lichten automatisch aan of uit gaan.",
    ],
    technieken: ["Python", "Raspberry Pi", "Lichtsensor"],
  },
  {
    naam: "Digitale veilingsklok",
    datum: "2025-01",
    zelfvoldoening: 4,
    afbeelding: {
      src: "images/petalbid.jpg",
      alt: "Voorbeeld van het logo van de digitale veilingsklok site.",
    },
    beschrijving: [
      "De digitale veilingsklok is een project dat ik heb gemaakt tijdens dezelfde module als nu, multilayer webdevelopment. ",
	  "Het is een webapplicatie die een veilingsklok simuleert.",
	  "De klok telt af en toont de resterende tijd. Als de tijd op is, wordt de veiling gesloten en kan er niet meer geboden worden.",
    ],
    technieken: ["Heel klein beetje docker", "C#", "React"],
  },
  {
    naam: "Wavelength",
    datum: "2026-04",
    zelfvoldoening: 5,
    afbeelding: {
      src: "images/wavelength.jpg",
      alt: "Wavelength logo",
    },
    beschrijving: [
      "Het wavelength project is een project dat ik heb gemaakt tijdens de module data engineering en AI, dit was een superleuke applicatie om te maken.",
      "Het is een webapplicatie die je Spotify-account inleest met je vrienden. Vervolgens worden al jullie liedjes en artiesten ingelezen en wordt er een profiel voor jullie gemaakt.",
      "Uit dat profiel kun je zien welke artiesten worden voorgesteld op basis van die keuzes, met directe linkjes naar concerten van die artiesten.",
      "Het was super om te zien hoe dit werkte en ook leuk om te gebruiken.",
    ],
    technieken: ["TypeScript", "CSS"],
  },
];
/* project laten zien*/
const projectloader = document.querySelector("#projectloader");

for (const project of projecten) {
  let beschrijvingHtml = "";
  let techniekenHtml = "";

  for (const tekst of project.beschrijving) {
    beschrijvingHtml += `<p>${tekst}</p>`;
  }

  for (const techniek of project.technieken) {
    techniekenHtml += `<li>${techniek}</li>`;
  }

  projectloader.innerHTML += `
    <article class="project" data-datum="${project.datum}" data-zelfvoldoening="${project.zelfvoldoening}">
      <img src="${project.afbeelding.src}" alt="${project.afbeelding.alt}">
      <div>
        <h2>${project.naam}</h2>
        ${beschrijvingHtml}
        <p>
          <strong>Datum:</strong> ${project.datum}
          · <strong>Zelfvoldoening:</strong> ${project.zelfvoldoening}/5
        </p>
        <h3>Gebruikte technieken</h3>
        <ul>
          ${techniekenHtml}
        </ul>
      </div>
    </article>
  `;
}
/* sorteren dom 2 en 3 */
const sorteerKeuze = document.querySelector("#sorteer-keuze");
const sorteerRichting = document.querySelector("#sorteer-richting");

function sorteerProjecten() {
  const eigenschap = sorteerKeuze.value;
  const richting = sorteerRichting.value === "oplopend" ? 1 : -1;
  const projectenOpPagina = [...projectloader.querySelectorAll(".project")];

  projectenOpPagina.sort((a, b) => {
    let waardeA;
    let waardeB;

    if (eigenschap === "datum") {
      waardeA = a.dataset.datum;
      waardeB = b.dataset.datum;
    } else {
      waardeA = Number(a.dataset.zelfvoldoening);
      waardeB = Number(b.dataset.zelfvoldoening);
    }

    if (waardeA < waardeB) return -1 * richting;
    if (waardeA > waardeB) return 1 * richting;
    return 0;
  });

  for (const project of projectenOpPagina) {
    projectloader.appendChild(project);
  }
}

sorteerKeuze.addEventListener("change", sorteerProjecten);
sorteerRichting.addEventListener("change", sorteerProjecten);