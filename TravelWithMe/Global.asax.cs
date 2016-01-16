using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace TravelWithMe
{
    public class Global : System.Web.HttpApplication
    {
        public static int totalNumberOfUsers = 0;
        public static int currentNumberOfUsers = 0;
        public static String currDate = null;
        public static String currTime = null;
        
        protected void Application_Start(object sender, EventArgs e)
        {

            Application["title"] = "Travel Guide";
           
           
        }
        protected void Application_End(object sender, EventArgs e)
        {

            
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Application.Lock();
            
          totalNumberOfUsers += 1;
          currentNumberOfUsers += 1;
          Application.UnLock();
           
           
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
           currDate =  DateTime.Now.ToShortDateString();
           currTime = DateTime.Now.ToShortTimeString();
           
           
            
        }

       protected void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            currentNumberOfUsers -= 1;
            Application.UnLock();
          
             }

      
    }
}