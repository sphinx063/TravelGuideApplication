using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelWithMe.TravelPlaces;
using TravelWithMe.NewsFocusService;
using TravelWithMe.NearestStoreService;
using TravelWithMe.CrimeData;
using TravelWithMe.HotelService;
using TravelWithMe.EventFinderService;
namespace TravelWithMe
{
   

    public partial class MemberPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                if (Session["name"] == null)
                {
                    Response.Redirect("login.aspx");
                }

                MaintainScrollPositionOnPostBack = true;
                userlabel.Text = Session["name"].ToString();

                HttpCookie myCookies = Request.Cookies["myCookieId"];


                if ((myCookies == null) || (myCookies["city"] == ""))
                {

                }
                else
                {
                    labelcity.Text = myCookies["City"];
                    strtlabel.Text = myCookies["start"];
                    endlabel.Text = myCookies["end"];

                }
            }
        }
        protected void button1_Click(object sender, EventArgs e)
        {
            mandError.Text = "";
            dateError.Text = "";
            HttpCookie myCookies = new HttpCookie("myCookieId");
            if (String.IsNullOrEmpty(city.Text) || String.IsNullOrEmpty(startdate.SelectedDate.ToShortDateString()) || String.IsNullOrEmpty(enddate.SelectedDate.ToShortDateString()))
            {
                mandError.Text = "Atleast one madatory field is empty";
            }
            else
            {
                if (startdate.SelectedDate > enddate.SelectedDate || startdate.SelectedDate < DateTime.Now.Date || enddate.SelectedDate < DateTime.Now.Date)
                {
                    dateError.Text = "Both dates should be ahead of today's date and start date should be greater than start date";
                }
                else
                {
                    myCookies["City"] = city.Text;
                    myCookies["start"] = startdate.SelectedDate.ToShortDateString();
                    myCookies["end"] = enddate.SelectedDate.ToShortDateString();
                    Session["name"] = userlabel.Text;

                    myCookies.Expires = DateTime.Now.AddMonths(6);
                    Response.Cookies.Add(myCookies);
                    labelcity.Text = myCookies["City"];
                    strtlabel.Text = myCookies["start"];
                    endlabel.Text = myCookies["end"];

                    Session["cityName"] = city.Text;
                    Session["startDate"] = startdate.SelectedDate.ToShortDateString();
                    Session["endDate"] = enddate.SelectedDate.ToShortDateString();
                    Session["defaultTime"] = startdate.SelectedDate.ToShortTimeString();

                    PopularPlaceFinderClient client = new PopularPlaceFinderClient();
                    ListBox1.Items.Clear();
                    String[] eventArrray = client.getNearByPopularPlaces(city.Text);
                    for (int i = 0; i < eventArrray.Length; i++)
                    {
                        ListBox1.Items.Add(eventArrray[i]);
                    }

                    String[] topics = { city.Text };
                    NewsFocusClient client2 = new NewsFocusClient();
                    String[] newsArray = client2.getNews(topics);
                    ListBox2.Items.Clear();
                    for (int i = 0; i < newsArray.Length; i++)
                    {
                        ListBox2.Items.Add(newsArray[i]);
                    }

                    EventFinderClient client3 = new EventFinderClient();
                    ListBox4.Items.Clear();
                    String[] eventArray = client3.getCurrentEvents(city.Text);
                    for (int i = 0; i < eventArray.Length; i++)
                    {
                        ListBox4.Items.Add(eventArray[i]);
                    }
                    HotelFinderClient client4 = new HotelFinderClient();
                    ListBox3.Items.Clear();
                    String[] hotelList = client4.findHotels(city.Text);
                    for (int i = 0; i < hotelList.Length; i++)
                    {
                        ListBox3.Items.Add(hotelList[i]);
                    }
                }
            }
           }

        

        protected void hotel_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(labelcity.Text) || String.IsNullOrEmpty(strtlabel.Text) || String.IsNullOrEmpty(endlabel.Text))
            {
                error.Text = "Make sure you have submitted the city, startdate and end date above";
            }  else
                Session["name"] = userlabel.Text;
            Session["cityName"] = labelcity.Text;
               Session["startDate"] = strtlabel.Text;
            
              Session["endDate"] = endlabel.Text;
                    
                Response.Redirect("hoteldetails.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
          //  NearestStoreClient client = new NearestStoreClient();
         // result.Text =  client.findNearestStore(zip.Text, store.Text);
        
        }
    }
}