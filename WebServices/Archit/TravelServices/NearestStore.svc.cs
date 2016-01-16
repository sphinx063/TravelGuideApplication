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

namespace TravelAdvisor
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "NearestStore" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select NearestStore.svc or NearestStore.svc.cs at the Solution Explorer and start debugging.
    public class NearestStore : INearestStore
    {
        public void DoWork()
        {
        }

        public String findNearestStore(String location, String term) { 
        String consumerKey = "";
	    String consumerSecret = "";
	    String token = "";
	    String tokenSecret = "";
        String baseUrl = "http://api.yelp.com/v2/";
        String url = "search/";

        String limit = "1";
        String sort = "1";

        RestClient client = new RestClient(baseUrl);
        client.Authenticator = OAuth1Authenticator.ForProtectedResource(consumerKey, consumerSecret, token, tokenSecret);
        RestRequest request = new RestRequest(url, Method.GET);
        request.AddParameter("term", term);
        request.AddParameter("location", location);
        request.AddParameter("limit", limit);
        request.AddParameter("sort", sort);
        RestResponse response = (RestResponse)client.Execute(request);

          String stringResponse = response.Content.ToString();
          dynamic stuff = JsonConvert.DeserializeObject(stringResponse);
          JArray business = stuff.businesses;
          String message = "";
          String rating = "";
           foreach (JObject content in business.Children<JObject>())
           {
               foreach (JProperty prop in content.Properties())
               {
                   if (prop.Name == "name")
                   {
                       message = message + prop.Value.ToString();
                   } 
                   if (prop.Name == "rating")
                   {
                       rating = prop.Value.ToString();
                   }       
                  
                   if (prop.Name == "location")
                   {
                       JObject obj = JObject.Parse(prop.Value.ToString());

                       foreach (JProperty prop1 in obj.Properties())
                       {
                           
                           if (prop1.Name == "display_address")
                           {
                               dynamic address = prop1.Value;
                               message = message + " || Address : " + address[0]+","+address[1];
                           }
                       }
                       
                   }
                    }
           }
           message = message + " || Yelp rating : " + rating;
              
               return message;



        }
    }
}
