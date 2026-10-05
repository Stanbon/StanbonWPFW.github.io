const button = document.getElementById("sortButton");
const projecten = [
  {
    titel: "Autohome",
    beschrijving: "Een simpele home-assistant-fork gemaakt op een Raspberry Pi.",
    datum: "2024-01",
	zelfvoldoening: "2/5",
  },
  {
    titel: "Digitale veilingsklok",
    beschrijving: "Een webapplicatie die een veilingsklok simuleert.",
    datum: "2025-01",
	zelfvoldoening: "4/5"
  },
  {
	titel: "Wavelength project",
	beschrijving: "Een webapplicatie voor spotify die je muzieksmaak onderzoekt en concerten voor je zoekt",
	datum: "2026-04",
	zelfvoldoening: "5/5"
  }
];
function kliksort() {
	sorteren(projecten, "datum");
  }

button.addEventListener("click", kliksort);