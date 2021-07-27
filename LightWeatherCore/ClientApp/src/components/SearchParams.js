import React, { useEffect, useState } from "react";

const SearchParams = ({
  setLocation,
  token,
  setCurrentWeather,
  coordinates,
}) => {
  const [location, updateLocation] = useState("");

  async function getWeatherData() {
    const res = await fetch(`/weatherdata/${location}?token=${token}`);

    const json = await res.json();
    setLocation(location);
    setCurrentWeather(json);
  }

  useEffect(() => {
    async function doIt() {
        setLocation("loading current location...");
        if (coordinates.longitude !== undefined && coordinates.latitude !== undefined) {
            console.log("coords are good to go");
          const res = await fetch(
            `/weatherdata/coordinates/${coordinates.longitude},${coordinates.latitude}?token=${token}`
          );
          const json = await res.json();
          console.log("My Json: " + json);
          setCurrentWeather(json);
          setLocation(json.locationName);
        }
    }
    doIt();
  }, [coordinates, token]);

  return (
    <div>
      <form
        onSubmit={(e) => {
          e.preventDefault();
          if (document.getElementById("location").value.length > 0) {
            setLocation("");
            getWeatherData();
          }
        }}
      >
        <label htmlFor="location">
          Location{" "}
          <input
            id="location"
            value={location}
            placeholder="Location"
            onChange={(e) => updateLocation(e.target.value)}
          />
        </label>
        <br></br>
        <button>Submit</button>
      </form>
    </div>
  );
};

export default SearchParams;
