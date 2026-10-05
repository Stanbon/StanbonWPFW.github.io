const weerTekst = document.querySelector("#weer-tekst");

async function laadWeer() {
  try {
    const response = await fetch("/JS functies/weather.js");

    if (!response.ok) {
      throw new Error(`Serverfout: ${response.status}`);
    }

    const resultaat = await response.json();
    const weer = resultaat.data;

    weerTekst.textContent =
      `Temperatuur: ${weer.tempC} °C | Wind: ${weer.windKph} km/u uit het ${weer.windDir}`;
  } catch (error) {
    console.error(error);
    weerTekst.textContent = "Het weer kon niet geladen worden.";
  }
}

laadWeer();