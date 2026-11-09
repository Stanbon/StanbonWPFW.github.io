const API_BASE_URL = "https://YOUR-API-URL.azurewebsites.net";
const blogloader = document.querySelector("#blogloader");
const blogStatus = document.querySelector("#blog-status");

function formatteerDatum(datum) {
  return new Intl.DateTimeFormat("nl-NL", {
    day: "2-digit",
    month: "long",
    year: "numeric"
  }).format(new Date(`${datum}T00:00:00`));
}

async function laadBlogposts() {
  try {
    const response = await fetch(`${API_BASE_URL}/api/blogposts`);

    if (!response.ok) {
      throw new Error(`API gaf status ${response.status}`);
    }

    const blogposts = await response.json();
    blogloader.replaceChildren();

    for (const blogpost of blogposts) {
      const artikel = document.createElement("article");
      artikel.className = "blog-bericht";

      const titel = document.createElement("h2");
      titel.textContent = blogpost.titel;

      const datum = document.createElement("p");
      datum.className = "datum";
      datum.textContent = formatteerDatum(blogpost.publicatiedatum);

      const inhoud = document.createElement("p");
      inhoud.textContent = blogpost.inhoud;

      artikel.append(titel, datum, inhoud);
      blogloader.append(artikel);
    }

    blogStatus.hidden = true;
  } catch (error) {
    console.error(error);
    blogStatus.textContent =
      "Blogposts kunnen niet worden geladen. Controleer of de API online is.";
  }
}

laadBlogposts();
