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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "NewsFocus" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select NewsFocus.svc or NewsFocus.svc.cs at the Solution Explorer and start debugging.
    public class NewsFocus : INewsFocus
    {
        public void DoWork()
        {
        }

        public String[] getNews(String[] topics) {
            topics = topics.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            String baseUrl = "https://webhose.io/search?token="your token";
            String[] emptyArray=new String[1];
            if(topics.Length==0){
            emptyArray[1]="please give some input";
            return emptyArray;
            }

            String query = "&q=";
            for (int i = 0; i < topics.Length; i++)
            {
                    if (i < topics.Length - 1)
                    {
                        query = query + topics[i] + " OR ";
                    }
                    else query = query + topics[i];
                
            }

            query = query + "&language=english" + "&size=100"+"&is_first=true";
            
            HttpWebRequest request = WebRequest.Create(baseUrl+query) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(response.GetResponseStream());

            XmlNodeList nl = xmlDoc.GetElementsByTagName("post");
            String[] res = new String[nl.Count];
           for (int i = 0; i < nl.Count; i++)
            {
                res[i] = nl.Item(i).ChildNodes.Item(2).InnerText;
             }
            return res;
		        
        }


    }
}
