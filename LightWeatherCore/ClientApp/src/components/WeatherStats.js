import TextDataPoint from "./TextDataPoint";
import React from 'react';

const WeatherStats = ({ currentWeather }) => {
  return (
    <div className="flex-grid">
      <TextDataPoint
        className
        dataPointTitle="Conditions"
        dataPointData={Capitalize(currentWeather.symbolPhrase)}
        units=""
      />
      <TextDataPoint
        dataPointTitle="Real Temp"
        dataPointData={ConvertToFahrenheit(currentWeather.temperature)}
        units={String.fromCharCode(176)}
      />
      <TextDataPoint
        dataPointTitle="Feels Like"
        dataPointData={ConvertToFahrenheit(currentWeather.feelsLikeTemp)}
        units={String.fromCharCode(176)}
      />
      <TextDataPoint
        dataPointTitle="Dew Point"
        dataPointData={ConvertToFahrenheit(currentWeather.dewPoint)}
        units={String.fromCharCode(176)}
      />
      <TextDataPoint
        dataPointTitle="Cloudiness"
        dataPointData={currentWeather.cloudiness}
        units="mph"
      />
      <TextDataPoint
        dataPointTitle="Wind Gust"
        dataPointData={currentWeather.windGust}
        units="mph"
      />
      <TextDataPoint
        dataPointTitle="Average Wind Speed"
        dataPointData={currentWeather.windSpeed}
        units="mph"
      />
    </div>
  );

  function ConvertToFahrenheit(celcius) {
    return Math.round(celcius * (9 / 5) + 32);
  }

  function Capitalize(str) {
    return str.replace(/\w\S*/g, function (txt) {
      return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase();
    });
  }
};

export default WeatherStats;
