using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using Newtonsoft.Json.Linq;
using System.IO;

namespace TravelServicesWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CrimeData" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CrimeData.svc or CrimeData.svc.cs at the Solution Explorer and start debugging.
    public class CrimeData : ICrimeData
    {
       public int getCrimeData(int zipcode)
        {
            String url = "https://azure.geodataservice.net/GeoDataService.svc/GetUSDemographics?includecrimedata=true&$format=json&zipcode=";
            String completeUri = url + zipcode;
            HttpWebRequest request = WebRequest.Create(completeUri) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream,Encoding.UTF8);
            String jsonResponse = reader.ReadToEnd();
            
            dynamic jsonRoot = JsonConvert.DeserializeObject(jsonResponse);
            JArray dataArray = jsonRoot.d;
            String burglary;
            String ViolentCrime;
            String LarcenyTheft; 
            String PropertyCrime; 
            String AggravatedAssault;
            String ForcibleRape;
            String Robbery;
            int totalCrimes = 0;
            foreach (JObject content in dataArray.Children<JObject>())
            {
                burglary = content.Property("Burglary").Value.ToString();
                ViolentCrime = content.Property("ViolentCrime").Value.ToString();
                LarcenyTheft = content.Property("LarcenyTheft").Value.ToString();
                PropertyCrime = content.Property("PropertyCrime").Value.ToString();
                AggravatedAssault = content.Property("AggravatedAssault").Value.ToString();
                ForcibleRape = content.Property("ForcibleRape").Value.ToString();
                Robbery = content.Property("Robbery").Value.ToString();
                totalCrimes = Convert.ToInt32(burglary) + Convert.ToInt32(ViolentCrime) + Convert.ToInt32(LarcenyTheft)
                    + Convert.ToInt32(PropertyCrime) + Convert.ToInt32(AggravatedAssault) + Convert.ToInt32(ForcibleRape)
                    + Convert.ToInt32(Robbery);

            }
            
            return totalCrimes;
        }
    }
}
