using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Net;
using System.Xml.XPath;
using System.ServiceModel.Activation;
namespace TravelRESTful
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "NearbyEventFinder" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select NearbyEventFinder.svc or NearbyEventFinder.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class NearbyEventFinder : INearbyEventFinder
    {
        public const String EVENTFUL_API_KEY = "YOUR_API_KEY";
        public const String EVENTFUL_BASE_URI = "http://api.eventful.com/rest/events/search";
       public List<EventDetails> getCurrentEvents(string cityName)
        {
            String eventUri = EVENTFUL_BASE_URI + "?l=" + cityName + "&within=25&app_key=" + EVENTFUL_API_KEY;
            List<EventDetails> eventList = queryEvents(eventUri);
            return eventList;
        }
        List<EventDetails> queryEvents(String uri)
        {
            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            XPathDocument document = new XPathDocument(response.GetResponseStream());
            XPathNavigator navigator = document.CreateNavigator();
            XPathNodeIterator iterator = navigator.Select("/search/events/event");
            String eventTitle = null;
            String venueName = null;
            String eventTime = null;
            String eventUrl = null;
            String eventDetails = "";
            List<EventDetails> eventList = new List<EventDetails>();
            EventDetails currentEvent = null;
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
                innerIterator = iterator.Current.Select("url");
                innerIterator.MoveNext();
                eventUrl = innerIterator.Current.Value;
                currentEvent = new EventDetails();
                currentEvent.Title = eventTitle;
                currentEvent.Venue_name = venueName;
                currentEvent.Event_Url = eventUrl;
                currentEvent.Start_time = eventTime;
                eventList.Add(currentEvent);
                //eventDetails = eventDetails + " || " + eventTitle + " @ " + venueName;
            }
            return eventList;
        }
    }
}
