using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

using System.Web.Services;

namespace WebApplication2
{
    /// <summary>
    /// Summary description for EmailService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class EmailService : System.Web.Services.WebService
    {

        [WebMethod]
        public static string SendEmail(string txtName, string txtEmail, string txtPhone, string txtComments, string txtAddress)
        {
            try
            {
                MailMessage msg = new MailMessage(ConfigurationManager.AppSettings["HomeEmailFrom"], ConfigurationManager.AppSettings["HomeEmailTo"]);
                msg.Subject = ConfigurationManager.AppSettings["HomeMailSubject"];
                StringBuilder str = new StringBuilder();
                str.AppendFormat("<table style='width:100%'>");
                str.AppendFormat("<tr>");
                str.AppendFormat("<td>Name :</td>");
                str.AppendFormat("<td>{0}</td>", txtName);
                str.AppendFormat("</tr>");
                str.AppendFormat("<tr>");
                str.AppendFormat("<td>Email :</td>");
                str.AppendFormat("<td>{0}</td>", txtEmail);
                str.AppendFormat("</tr>");
                str.AppendFormat("<tr>");
                str.AppendFormat("<td>Phone :</td>");
                str.AppendFormat("<td>{0}</td>", txtPhone);
                str.AppendFormat("</tr>");
                str.AppendFormat("<tr>");
                str.AppendFormat("<td>Comments :</td>");
                str.AppendFormat("<td>{0}</td>", txtComments);
                str.AppendFormat("</tr>");
                str.AppendFormat("<tr>");
                str.AppendFormat("<td>Comments :</td>");
                str.AppendFormat("<td>{0}</td>", txtAddress);
                str.AppendFormat("</tr>");
                str.AppendFormat("</table>");
                msg.IsBodyHtml = true;
                msg.Body = str.ToString();
                SmtpClient smtp = new SmtpClient();
                smtp.EnableSsl = true;
                smtp.Send(msg);
                return ConfigurationManager.AppSettings["HomeThanksMsg"];
            }
            catch (Exception ex)
            {
                return "An error occured in sending mail " + ex.Message;
            }
        }
    }
}
