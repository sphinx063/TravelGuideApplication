using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyDLL;

namespace TravelWithMe
{
    public partial class StaffSignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["StaffName2"]!=null)
            staffun.Text = Session["StaffName2"].ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (pwd.Text.Equals(cnf.Text))
            {
                Hashing hash = new Hashing();
                String hashpwd = hash.createHash(pwd.Text);
                List<String> details = new List<String>();
                details.Add(un.Text);
                details.Add(hashpwd);
                details.Add(email.Text);
                XMLManipulator man = new XMLManipulator();
               Boolean flag = man.saveToXML(details,false);
               if (flag == false) {
                   msg.Text= "username aleady exists";}
                   else{
                       HttpCookie myCookies = new HttpCookie("myCookieId");
                       myCookies["NameUser"] = un.Text;
                       myCookies.Expires = DateTime.Now.AddMonths(6);
                       Response.Cookies.Add(myCookies);
                       msg.Text = "Name stored in cookiesis registered = "  + myCookies["NameUser"] ;

                   }
               }
            
            else {
                msg.Text = "passwords are not same";
            }
        }

        protected void pwd_TextChanged(object sender, EventArgs e)
        {

        }
    }
}