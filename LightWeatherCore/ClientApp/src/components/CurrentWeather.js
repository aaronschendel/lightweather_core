import WeatherStats from "./WeatherStats";
import React from 'react';

const CurrentWeather = ({ location, currentWeather }) => {
  return (
    <div>
      <h2>Current Weather - {location}</h2>
      <div>
        {currentWeather !== "" ? (
          <WeatherStats currentWeather={currentWeather} />
        ) : (
          ""
        )}
      </div>
    </div>
  );
};

export default CurrentWeather;
