using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using YelpSharp.Data;
using YelpSharp.Data.Options;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;
namespace TravelServicesWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PopularPlaceFinder" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PopularPlaceFinder.svc or PopularPlaceFinder.svc.cs at the Solution Explorer and start debugging.
    public class PopularPlaceFinder : IPopularPlaceFinder
    {
        public const String API_KEY = "IKQ2O7h_ZWsi0wzM-bE_Jw";
	    public const String API_SECRET = "NbBACJHEKSRlcSngvGNj1le5xpI";
	    public const String API_TOKEN = "6ZMHtzRA2PrkIWDV11FiWUKnQXCBSvF1";
	    public const String API_TOKEN_SECRET = "FwfOl74e2AQMqpDMDN88SXcucTQ";
        public const String YELP_BASE_URI = "http://api.yelp.com/v2/";
        public List<String> getNearByPopularPlaces(String cityName)
        {
            List<String> popularPlaces = queryPlaces(cityName);
            return popularPlaces;
        }
        List<String> queryPlaces(String cityName)
        {
           String searchPath = "search/";
           String jsonString = null;
           RestResponse response = null;
           RestRequest request = null;
           RestClient client = null;
           dynamic jsonRoot = null;
           JArray business = null;
           List<String> placeList = new List<String>();
           client = new RestClient(YELP_BASE_URI);
           client.Authenticator = OAuth1Authenticator.ForProtectedResource(API_KEY, API_SECRET, API_TOKEN, API_TOKEN_SECRET);
           request = new RestRequest(searchPath, Method.GET);
           request.AddParameter("term", "tourists must see list");
           request.AddParameter("location", cityName);
           response = (RestResponse)client.Execute(request);
           jsonString = response.Content.ToString();
           jsonRoot = JsonConvert.DeserializeObject(jsonString);
           business = jsonRoot.businesses;
      //   String myResponse = "";
            
           String placeDetails = "";
           foreach (JObject content in business.Children<JObject>())
           {

               placeDetails = "";
               placeDetails = content.Property("name").Value.ToString();
               JObject location = JObject.Parse(content.Property("location").Value.ToString());
               if (location.Property("display_address").Value is JArray)
               {
                   placeDetails = placeDetails + " at";
                   JArray addressLines = (JArray)location.Property("display_address").Value;
                   foreach (JToken token in addressLines.Children())
                   {
                       placeDetails = placeDetails +" "+ token.ToString();
                   }
               }
               placeList.Add(placeDetails);
          /*     
               foreach (JProperty prop in content.Properties())
               {
                  // if (prop.Name == "name")
                   //{
                   //    myResponse = myResponse + ", " + prop.Value.ToString();
                   //}
                   if (prop.Name == "location")
                   {
                       JObject obj = JObject.Parse(prop.Value.ToString());
                       foreach (JProperty prop1 in obj.Properties())
                       {
                           if (prop1.Name == "display_address")
                           {
                               dynamic address = prop1.Value;
                               myResponse = myResponse + address[0]+","+address[1];
                           }
                       }
                       
                   }// This is not allowed 
                   //here more code in order to save in a database
               }*/
           }
               return placeList;

        }
        
    }
}
