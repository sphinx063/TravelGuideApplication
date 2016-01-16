using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using TravelWithMe.ImageVerifierService;
namespace TravelWithMe
{
    public partial class ImageVerifier : System.Web.UI.Page
    {
        private static String verificationString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Image1.Visible = true;
                ImageVerifierService.ServiceClient client = new ImageVerifierService.ServiceClient(); 
                verificationString = client.GetVerifierString("7");
                Stream stream = client.GetImage(verificationString);
                string savePath = Server.MapPath(@"Images\hw.jpg");
                //String saveLocation = Path.Combine(Request.PhysicalApplicationPath, @"App_Data\"+"myImage.jpeg");

                System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
                image.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                string imageName = "~/Images/hw.jpg";
                //Image1.ImageUrl = "C:\\VSProjects\\TravelGuide\\TravelGuide\\App_Data\\myImage.jpeg";
                Image1.ImageUrl = imageName;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //TextBox1.Text = verificationString;
            if (TextBox1.Text.Equals(verificationString))
            {
                Response.Redirect("MemberRegistration.aspx");
                //Image1.Visible = false;
            }
            else
            {
                Label1.Text = "Try Again";
                ImageVerifierService.ServiceClient client = new ImageVerifierService.ServiceClient();
                verificationString = client.GetVerifierString("7");
                Stream stream = client.GetImage(verificationString);
                string savePath = Server.MapPath(@"Images\hw.jpg");
                //String saveLocation = Path.Combine(Request.PhysicalApplicationPath, @"App_Data\"+"myImage.jpeg");
                System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
                image.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                string imageName = "~/Images/hw.jpg";
                //Image1.ImageUrl = "C:\\VSProjects\\TravelGuide\\TravelGuide\\App_Data\\myImage.jpeg";
                Image1.ImageUrl = imageName;
            }
        }
    }
}