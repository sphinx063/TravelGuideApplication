using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyDLL;

namespace TravelWithMe
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "admin")
            {
                Hashing hash = new Hashing();
                String hashpwd = hash.createHash(TextBox2.Text);
                XMLManipulator man = new XMLManipulator();
                Boolean flag = man.authenticateUser(TextBox1.Text, hashpwd,false);

                if (flag == true)
                {
                    HttpCookie myCookies = new HttpCookie("myCookieId");
                    myCookies["StaffName2"] = TextBox1.Text;
                    myCookies.Expires = DateTime.Now.AddMonths(6);
                    Response.Cookies.Add(myCookies);
                   

                    Session["StaffName2"] = TextBox1.Text;

                    Session["flag"] = "true";
                    Response.Redirect("StaffSignUp.aspx");  // Return to catalog page
                    
                }
                else
                {
                    Label1.Text = "Invalid Password";
                }


            }
            else Label1.Text = "invalid user";
        }
    }
}