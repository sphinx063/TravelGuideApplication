using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelWithMe
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             
                 }

        protected void member_Click(object sender, EventArgs e)
        {
            if (Session["name"]==null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Response.Redirect("MemberPage.aspx");
            }
        }

        protected void staff_Click(object sender, EventArgs e)
        {
            if (Session["StaffName"] == null)
            {
                Response.Redirect("StaffLogin.aspx");
            }
            else
            Response.Redirect("StaffPage.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ImageVerifier.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Session["StaffName2"] == null)
            {
                Response.Redirect("AdminLogin.aspx");
            }
            else { Response.Redirect("StaffSignUp.aspx"); }
        }
    }
}