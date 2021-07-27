import SearchParams from "./SearchParams";
import CurrentWeather from "./CurrentWeather";
import React, { useEffect, useState } from "react";
import './index.css';

const LightWeather = () => {
    const [token, updateToken] = useState("");
    const [location, setLocation] = useState("");
    const [currentWeather, setCurrentWeather] = useState("");
    const [coordinates, setCoordinates] = useState([]);

    async function GetToken() {
        const res = await fetch("weatherdata/token");
        const json = await res.json();
        console.log("My token: " + json.access_token);
        updateToken(json.access_token);
    }

    useEffect(() => {
        GetToken();
        if ("geolocation" in navigator) {
            console.log("Available");
        } else {
            console.log("Not Available");
        }
        navigator.geolocation.getCurrentPosition(function (position) {
            setCoordinates({
                latitude: position.coords.latitude,
                longitude: position.coords.longitude,
            });
            console.log("Latitude is :", position.coords.latitude);
            console.log("Longitude is :", position.coords.longitude);
        });
    }, []);

    return (
        <div>
            <SearchParams
                setLocation={setLocation}
                setCurrentWeather={setCurrentWeather}
                token={token}
                coordinates={coordinates}
            />
            <CurrentWeather
                location={location}
                currentWeather={currentWeather}
                coordinates={coordinates}
            />
        </div>
    );

    //async function populateWeatherData() {
    //    const response = await fetch('weatherforecast');
    //    const data = await response.json();
    //    this.setState({ forecasts: data, loading: false });
    //}

};

export default LightWeather;
