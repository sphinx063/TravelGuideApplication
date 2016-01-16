using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyDLL;

namespace TravelWithMe
{
    
    public partial class Login : System.Web.UI.Page
    {
        private static String usern;

        public static String Usern
        {
            get { return Login.usern; }
            set { Login.usern = value; }
        }
        
                protected void Page_Load(object sender, EventArgs e)
        {    
            Session["flag"] = "false";
            HttpCookie myCookies = Request.Cookies["myCookieId"];
            if ((myCookies == null) || (myCookies["Name"] == ""))
            {
                unlabel.Text = "Welcome, new user";
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Hashing hash = new Hashing();
            String hashpwd= hash.createHash(pwd.Text);
            XMLManipulator man = new XMLManipulator();
          Boolean flag =  man.authenticateUser(un.Text, hashpwd,true);

          if (flag == true)
          {
              HttpCookie myCookies = new HttpCookie("myCookieId");
              myCookies["Name"] = un.Text;
              Session["name"] = un.Text;
              myCookies.Expires = DateTime.Now.AddMonths(6);
              Response.Cookies.Add(myCookies);
              unlabel.Text = "Name stored in cookies " + myCookies["Name"];

              Login.usern = un.Text;

             
              Session["flag"] = "true";
              Response.Redirect("MemberPage.aspx");  // Return to catalog page

          }
          else {
              unlabel.Text = "Invalid Username or Password";
          }
          }

        protected void pwd_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberRegistration.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Hashing hash = new Hashing();
            String hashpwd = hash.createHash(pwd.Text);
            Label1.Text = hashpwd;
        }
    }
}