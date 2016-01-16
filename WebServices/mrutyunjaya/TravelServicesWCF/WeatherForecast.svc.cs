using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Xml;
namespace TravelServicesWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WeatherForecast" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WeatherForecast.svc or WeatherForecast.svc.cs at the Solution Explorer and start debugging.
    public class WeatherForecast : IWeatherForecast
    {
        public const String WEATHER_API_KEY = "WEATHER_API_KEY";
        public const String ZIPCODE_API_KEY = "ZIPCODE_API_KEY";
        public const String MODE_XML = "xml";
        private String forecastString;
        private String zipcodeString;
        public List<String> getForecast(string zipcode)
        {
            String[] coordinates = getCoordinates(zipcode);
            String weather_url = "http://api.openweathermap.org/data/2.5/forecast/daily?lat=" + coordinates[0] + "&lon=" + coordinates[1] + "&mode=" + MODE_XML + "&APPID=" + WEATHER_API_KEY;
            List<String> weatherData = getWeatherByDay(weather_url);
            return weatherData;
        }
        private String[] getCoordinates(String zipcode){
            String[] coord = new String[2];
		    String zipcode_url = "https://www.zipcodeapi.com/rest/"+ZIPCODE_API_KEY+"/info.xml/"+zipcode+"/degrees";
            HttpWebRequest request = WebRequest.Create(zipcode_url) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            XmlDocument document = new XmlDocument();
            document.Load(response.GetResponseStream());
            XmlNodeList nodeList = document.GetElementsByTagName("lat");
            coord[0] = document.SelectSingleNode("response/lat").InnerText;
            coord[1] = document.SelectSingleNode("response/lng").InnerText;
		    return coord;
	}
        private List<String> getWeatherByDay(String weather_url){
            List<String> weatherForecast = new List<String>();
            HttpWebRequest request = WebRequest.Create(weather_url) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            XmlDocument document = new XmlDocument();
            document.Load(response.GetResponseStream());
            XmlNodeList forecastNodes = document.SelectSingleNode("weatherdata/forecast").ChildNodes;
            String forecast = null;
            String minTemp;
            String maxTemp;
            String humidity;
            String rainCondition;
            String date;
            int i = 0;
            foreach (XmlNode node in forecastNodes)
            {
                i++;
                if (i == 6)
                    break;
                date = node.Attributes["day"].Value;
                rainCondition = node.SelectSingleNode("symbol").Attributes["name"].Value;
                minTemp = Convert.ToString(convertToCelsius(Convert.ToDouble(node.SelectSingleNode("temperature").Attributes["min"].Value)));
                maxTemp = Convert.ToString(convertToCelsius(Convert.ToDouble(node.SelectSingleNode("temperature").Attributes["max"].Value)));
                humidity = node.SelectSingleNode("humidity").Attributes["value"].Value;
                forecast = date + " " + minTemp + "/" + maxTemp + " " + "humidity = " + humidity + "%" + " " + rainCondition;
                weatherForecast.Add(forecast);
                if (weatherForecast.Count == 0)
                    break;
            }

            return weatherForecast;
        }
        private double convertToCelsius(double tempInKelvin)
        {
            return tempInKelvin - 273.15f;
        }

    }
}
