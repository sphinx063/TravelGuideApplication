using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Net;
using System.Xml;
using System.Xml.XPath;
namespace TravelServicesWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EventFinder" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EventFinder.svc or EventFinder.svc.cs at the Solution Explorer and start debugging.
    public class EventFinder : IEventFinder
    {
        public const String EVENTFUL_API_KEY = "tz4wxWPpv9BDkV9z";
        public const String EVENTFUL_BASE_URI = "http://api.eventful.com/rest/events/search";
        
        public List<String> getCurrentEvents(string cityName)
        {
            String eventUri = EVENTFUL_BASE_URI + "?l=" + cityName + "&within=25&app_key="+EVENTFUL_API_KEY;
            List<String> eventList = queryEvents(eventUri);
            return eventList;
        }
          
        
        List<String> queryEvents(String uri)
        {
            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            XPathDocument document = new XPathDocument(response.GetResponseStream());
            XPathNavigator navigator = document.CreateNavigator();
            XPathNodeIterator iterator = navigator.Select("/search/events/event");
            String eventTitle = null;
            String venueName = null;
            String eventTime = null;
            String eventDetails = "";
            List<String> eventList = new List<String>();
            
            while (iterator.MoveNext())
            {

                XPathNodeIterator innerIterator = iterator.Current.Select("title");
                innerIterator.MoveNext();
                eventTitle = innerIterator.Current.Value;
                innerIterator = iterator.Current.Select("venue_name");
                innerIterator.MoveNext();
                venueName = innerIterator.Current.Value;
                innerIterator = iterator.Current.Select("start_time");
                innerIterator.MoveNext();
                eventTime = innerIterator.Current.Value;
                eventDetails = eventTitle + " at " + venueName + " on "+eventTime;
                eventList.Add(eventDetails);
            }
            return eventList;
        }
         
        
    }
}
