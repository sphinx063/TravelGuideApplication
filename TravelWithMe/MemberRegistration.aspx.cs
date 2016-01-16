using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyDLL;

namespace TravelWithMe
{
    public partial class MemberRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                Boolean flag = man.saveToXML(details, true);
                if (flag == false)
                {
                    msg.Text = "username aleady exists";
                }
                else { msg.Text = "Registered";
                Response.Redirect("Login.aspx");
                }
            }

            else
            {
                msg.Text = "passwords are not same";
            }
        }
    }
}