const weerTekst = document.querySelector("#weer-tekst");

async function laadWeer() {
  try {
    const url = "https://api.open-meteo.com/v1/forecast?latitude=52.0705&longitude=4.3007&current=temperature_2m,wind_speed_10m,wind_direction_10m&wind_speed_unit=kmh";
    const response = await fetch(url);

    if (!response.ok) {
      throw new Error("Het weer kon niet worden opgehaald.");
    }

    const resultaat = await response.json();
    const weer = resultaat.current;

    weerTekst.textContent =
      `Temperatuur: ${weer.temperature_2m} °C | Wind: ${weer.wind_speed_10m} km/u uit ${weer.wind_direction_10m}°`;
  } catch (error) {
    console.error(error);
    weerTekst.textContent = "Het weer kon niet geladen worden.";
  }
}

laadWeer();