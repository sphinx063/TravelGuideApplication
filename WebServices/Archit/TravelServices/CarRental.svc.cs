using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.XPath;
using System.Net;

namespace TravelAdvisor
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CarRental" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CarRental.svc or CarRental.svc.cs at the Solution Explorer and start debugging.
    public class CarRental : ICarRental
    {
        public void DoWork()
        {
        }
        public String[] carFinder(String destination,String startDate,String endDate, String pickTime, String dropOffTime) {
		String defaultUrl = "http://api.hotwire.com/v1/search/car?apikey="+"api key"+&dest="+destination+"&startdate="+startDate+"&enddate="+endDate+"&pickuptime="+pickTime+"&dropofftime="+dropOffTime;
        
            HttpWebRequest request = WebRequest.Create(defaultUrl) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(response.GetResponseStream());

            XmlNodeList nl = xmlDoc.GetElementsByTagName("CarResult");
            if (nl.Count != 0)
            {
                String[] result = new String[nl.Count];
                for (int i = 0; i < nl.Count; i++)
                {

                    result[i] = "[Car Type] " + nl.Item(i).ChildNodes.Item(7).InnerText
                            + " || [Total Price] " + nl.Item(i).ChildNodes.Item(6).InnerText
                            + " || [Pickup airport] " + nl.Item(i).ChildNodes.Item(15).InnerText
                            + " || [url] " + nl.Item(i).ChildNodes.Item(1).InnerText;


                }


                return result;
            }else {
                String[] emptyArray = new String[1];
            
                emptyArray[0]="Sorry!! No cabs, try some other option";
                return emptyArray;
            }
            
            

        }
    }
}
