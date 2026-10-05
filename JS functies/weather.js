import { guard, callApi, respond } from "../lib/apiverve.js";

export async function GET(request) {
  const blocked = guard(request);

  if (blocked) {
    return blocked;
  }

  return respond(() =>
    callApi("weatherforecast", {
      query: {
        city: "Den Haag",
      },
    })
  );
}