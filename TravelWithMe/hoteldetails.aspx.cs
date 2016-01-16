using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelWithMe.CarService;
using TravelWithMe.WaetherService;
using TravelWithMe.HotelService;
using TravelWithMe.EventFinderService;

namespace TravelWithMe
{
    public class City {
        public string _cityName;
        public City(String cityname) {
            _cityName = cityname;
        }
    }
    public partial class hoteldetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pick.Text = Session["startDate"].ToString();
                drop.Text = Session["endDate"].ToString();
                hotelcity.Text = Session["cityName"].ToString();
                if (Session["name"] != null)
                { un.Text = Session["name"].ToString(); }
                
            }
                    }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["name"] = un.Text;
            Response.Redirect("MemberPage.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
         }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Session["name"] = un.Text;
            Response.Redirect("Default.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ziperror.Text = "";
            Label2.Text = "";
            if (String.IsNullOrEmpty(zip.Text))
            {
                ziperror.Text = "please enter the zip code";
            }
            else
            {
                Session["startDate"] = pick.Text;
                Session["endDate"] = drop.Text;
                Session["cityName"] = hotelcity.Text;
                if (!String.IsNullOrEmpty(un.Text))
                    Session["name"] = un.Text;

                CarRentalClient client = new CarRentalClient();
                String picktime = "10:00";
                String dropTime = "23:00";
                if (Convert.ToInt32(h1.Text) > 24 || Convert.ToInt32(h2.Text) > 24 )
                {
                    Label2.Text = "hour should be less than 24";
                }
                else
                {
                    if ((Convert.ToInt32(m1.Text) == 30 || Convert.ToInt32(m1.Text) == 00) && (Convert.ToInt32(m2.Text) == 30 || Convert.ToInt32(m2.Text) == 00))
                    {
                        picktime = h1.Text + ":" + m1.Text;
                        dropTime = h2.Text + ":" + m2.Text;
                        String[] carArray = client.carFinder(zip.Text, pick.Text, drop.Text, picktime, dropTime);
                        ListBox1.Items.Clear();
                        for (int i = 0; i < carArray.Length; i++)
                            ListBox1.Items.Add(carArray[i]);

                        WeatherForecastClient client2 = new WeatherForecastClient();
                        String[] weatherArray = client2.getForecast(zip.Text);
                        ListBox4.Items.Clear();
                        for (int i = 0; i < weatherArray.Length; i++)
                        {
                            ListBox4.Items.Add(weatherArray[i]);
                        }
                    }
                    else Label2.Text = "Minutes should be 30 or 00 only";

                }
            }

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}