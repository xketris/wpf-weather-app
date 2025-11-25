# WPF Weather App

The **WPF Weather App** is a desktop application built with **C#** and **Windows Presentation Foundation (WPF)** on the **.NET 8** framework. It provides users with real-time weather information for any city worldwide.

The application integrates with the **OpenWeatherMap API** to fetch current data, including temperature, humidity, pressure, and weather conditions. It features a clean, responsive UI that dynamically updates based on the data received, utilizing standard WPF patterns like Data Binding and Value Converters.

**Key Features:**
* **City Search:** Users can enter a city name to retrieve specific weather data.
* **Dynamic UI:** Displays appropriate weather icons (sunny, cloudy, rain, etc.) based on the current conditions.
* **Error Handling:** Visually alerts the user if a city is not found or if there is a connection error.

## Status
Completed

## Demo
This is a Windows Desktop application. To test it, please follow the installation instructions below to run it locally on your machine.

## Development Server

To run this application locally, you will need a Windows environment with the .NET SDK installed.

### Prerequisites
* **OS:** Windows 10 or 11.
* **.NET 8 SDK**
* **IDE:** Visual Studio 2022 or JetBrains Rider.

### Installation & Setup

1.  **Clone the repository**
    ```bash
    git clone <repository-url>
    ```

2.  **Open the Project**
    * Open the `WeatherApp.sln` file in Visual Studio.

3.  **Restore Dependencies**
    * Visual Studio should automatically restore the NuGet packages (`Newtonsoft.Json`, `System.Net.Http`).
    * Alternatively, run:
        ```bash
        dotnet restore
        ```

4.  **Run the Application**
    * Press `F5` in Visual Studio or run the following command in the terminal:
        ```bash
        dotnet run
        ```

## License
This project currently has no specified license.

## Author
- [xketris](https://github.com/xketris)
