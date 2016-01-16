using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelWithMe
{
    public partial class HeaderUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "Travel Guide";
            Label2.Text = Convert.ToString(Global.totalNumberOfUsers);
            Label3.Text = Convert.ToString(Global.currentNumberOfUsers);
            Label5.Text = Global.currDate;
            Label6.Text = Global.currTime;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Session["name"] == null && Session["StaffName"] == null && Session["StaffName2"]==null)
            {
                Label4.Text = "Not logged in";
            }
            else
            {
                Session.Clear();
                Session.RemoveAll();
                Session.Abandon();
               
                Response.Redirect("Default.aspx");
                            }
        }
    }
}