using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.IO;
using System.Xml.XPath;
namespace TravelWithMe
{
    public class XMLManipulator
    {
        private const String MEMBER_XML = "Member.xml";
        private const String STAFF_XML = "Staff.xml";
        private bool ifMember = false;
        public bool saveToXML(List<String> credentials,bool isMember)
        {
            
            bool saveSuccess = false;
            ifMember = isMember;
            String fileLocation = null;
            if(isMember){
                fileLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\"+MEMBER_XML);
            }
            else{
                fileLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\"+STAFF_XML);
            }
            if (!File.Exists(fileLocation))
            {
                FileStream fs = null;
                try
                {
                    fs = new FileStream(fileLocation, FileMode.CreateNew);
                    XmlWriter writer = XmlWriter.Create(fs);
                    writer.WriteStartDocument();
                    if (isMember)
                    {
                        writer.WriteStartElement("users");
                        writer.WriteStartElement("user");
                        writer.WriteElementString("username", credentials[0]);
                        writer.WriteElementString("password", credentials[1]);
                        writer.WriteElementString("email", credentials[2]);
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                    }
                    else
                    {
                        writer.WriteStartElement("staff");
                        writer.WriteStartElement("user");
                        writer.WriteElementString("username", credentials[0]);
                        writer.WriteElementString("password", credentials[1]);
                        writer.WriteElementString("email", credentials[2]);
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                    }
                    writer.Close();
                    fs.Close();
                }
                finally
                {
                    fs.Close();
                }
                saveSuccess = true;
            }
            else
            {
                if (!isDuplicateUsername(credentials[0]))
                {
                    Stream fs = null;
                    try
                    {
                        // fs = new FileStream(fileLocation, FileMode.Open);
                        fs = new FileStream(fileLocation, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                        XmlDocument document = new XmlDocument();
                        document.Load(fs);
                        XmlNode user = document.CreateElement("user");
                        XmlNode username = document.CreateElement("username");
                        username.InnerText = credentials[0];
                        XmlNode password = document.CreateElement("password");
                        password.InnerText = credentials[1];
                        user.AppendChild(username);
                        user.AppendChild(password);
                        XmlNode email = document.CreateElement("email");
                        email.InnerText = credentials[2];
                        user.AppendChild(email);
                        document.DocumentElement.AppendChild(user);
                        fs.Position = 0;
                        document.Save(fs);
                        fs.Close();
                    }
                    finally
                    {
                        fs.Close();
                    }
                    saveSuccess = true;
                }
             
            }

            return saveSuccess;
        }
        public bool authenticateUser(String username,String hashedPassword,bool isMember){
            bool isAuthenticated = false;
            String fileLocation = null;
            if (isMember)
            {
                fileLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\" + MEMBER_XML);
            }
            else
            {
                fileLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\" + STAFF_XML);
            }
            FileStream fs = null;
            try
            {
               fs = new FileStream(fileLocation, FileMode.Open, FileAccess.Read);
               XmlDocument document = new XmlDocument();
               document.Load(fs);
               XmlNodeList userList = document.GetElementsByTagName("user");
               XmlNode temp = null;
               foreach (XmlNode user in userList)
               {
                   temp = user.FirstChild;
                   if (temp.InnerText == username)
                   {
                       if (temp.NextSibling.InnerText == hashedPassword)
                       {
                           isAuthenticated = true;
                           break;
                       } 
                   }
               }
               fs.Close();
            }
            finally
            {
                 fs.Close();
            }
            return isAuthenticated;
        }
        private bool isDuplicateUsername(String username)
        {
            bool isDuplicate = false;
            String fileLocation = null;
            if (ifMember)
            {
                fileLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\"+MEMBER_XML);
            }
            else
            {
                fileLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\" + STAFF_XML);
            }
            FileStream fs = null;
            try
            {
                fs = new FileStream(fileLocation, FileMode.Open, FileAccess.Read);
                XmlDocument document = new XmlDocument();
                document.Load(fs);
                XmlNodeList userList = document.GetElementsByTagName("user");
                XmlNode temp = null;
                foreach (XmlNode user in userList)
                {
                    temp = user.FirstChild;
                    if (temp.InnerText == username)
                    {
                            isDuplicate = true;
                            break;
                    }
                }
                fs.Close();
            }
            finally
            {
                fs.Close();
            }
            return isDuplicate;
        }
    }
}