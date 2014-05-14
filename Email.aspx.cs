using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Web.Services;
using System.Configuration;
using System.Text;

public partial class Email : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

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
            SmtpClient smtp = new SmtpClient("127.0.0.1");
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(msg);
            return ConfigurationManager.AppSettings["HomeThanksMsg"];
        }
        catch (Exception ex)
        {
            return "An error occured in sending mail " + ex.Message;
        }
    }

    [WebMethod]
    public static string SendEmailConnect(string txtName, string txtPhone, string txtEmail, string ddlNation, string ddlInquire)
    {
        try
        {
            MailMessage msg = new MailMessage(ConfigurationManager.AppSettings["ConnectEmailFrom"], ConfigurationManager.AppSettings["ConnectEmailTo"]);
            msg.Subject = ConfigurationManager.AppSettings["ConnectMailSubject"];
            StringBuilder str = new StringBuilder();
            str.AppendFormat("<table style='width:100%'>");
            str.AppendFormat("<tr>");
            str.AppendFormat("<td>Name :</td>");
            str.AppendFormat("<td>{0}</td>", txtName);
            str.AppendFormat("<\tr>");
            str.AppendFormat("<tr>");
            str.AppendFormat("<td>Email :</td>");
            str.AppendFormat("<td>{0}</td>", txtEmail);
            str.AppendFormat("<\tr>");
            str.AppendFormat("<tr>");
            str.AppendFormat("<td>Phone :</td>");
            str.AppendFormat("<td>{0}</td>", txtPhone);
            str.AppendFormat("<\tr>");
            str.AppendFormat("<tr>");
            str.AppendFormat("<td>Nationality :</td>");
            str.AppendFormat("<td>{0}</td>", ddlNation);
            str.AppendFormat("<\tr>");
            str.AppendFormat("<tr>");
            str.AppendFormat("<td>Inquiry About :</td>");
            str.AppendFormat("<td>{0}</td>", ddlNation);
            str.AppendFormat("<\tr>");
            str.AppendFormat("<\table>");
            msg.IsBodyHtml = true;
            msg.Body = str.ToString();
            SmtpClient smtp = new SmtpClient();
            smtp.EnableSsl = true;
            smtp.Send(msg);
            return ConfigurationManager.AppSettings["ConnectThanksMsg"];
        }
        catch (Exception ex)
        {
            return "An error occured in sending mail " + ex.Message;
        }
    }
}