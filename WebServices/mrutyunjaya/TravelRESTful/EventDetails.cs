using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace TravelRESTful
{
    [DataContract]
    public class EventDetails
    {
        private String title;
        [DataMember]
        public String Title
        {
            get { return title; }
            set { title = value; }
        }
        private String start_time;
        [DataMember]
        public String Start_time
        {
            get { return start_time; }
            set { start_time = value; }
        }
        private String venue_name;
        [DataMember]
        public String Venue_name
        {
            get { return venue_name; }
            set { venue_name = value; }
        }
        private String event_Url;
        [DataMember]
        public String Event_Url
        {
            get { return event_Url; }
            set { event_Url = value; }
        }
    }
}