using Shift4Payment.Assignment.BusinessLayer;
using Shift4Payment.Assignment.DataModelLayer.Models;
using Shift4Payment.Assignment.SharedLayer;
using System;
using System.Net;
using System.Net.Mail;

namespace Shift4Payment.Assignment.PresentationLayer
{
    public partial class PrintAgreement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPropertyDetails();
            }
        }

        /// <summary>
        /// load property details from database
        /// </summary>
        private void LoadPropertyDetails()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                int id = Convert.ToInt32(Request.QueryString["Id"]);
                var propertyBusiness = new PropertyBusiness();
                var result = propertyBusiness.GetPropertyById(id);
                if (result.Success && result.Model != null)
                {
                    TenantPropertyModel model = result.Model;
                    lblPropertyName.Text = model.PropertyName;
                    lblAddress.Text = model.Address;
                    lblCity.Text = model.City;
                    lblState.Text = model.State;
                    lblOwnerName.Text = model.OwnerName;
                    lblZip.Text = model.Zip;
                    txttenantFirstName.Text = model.Firstname;
                    txttenantLastName.Text = model.Lastname;
                    txtRentAmount.Text = model.Amount.ToString();
                    txtStartDate.Text = model.StartDate.ToString();
                    txtEndDate.Text = model.EndDate.ToString();
                }
            }
            else
            {
                litMsg.Text = "Invalid property Id";
            }

        }

        protected void btnSendEmail_Click(object sender, EventArgs e)
        {
            try
            {

                var fromAddress = new MailAddress(ReadConfig.FromEmail, "Admin");
                var toAddress = new MailAddress(ReadConfig.ToEmail, "Admin");
                string fromPassword = ReadConfig.SmtpPassword;
                string subject = "Rental Agreement";
                string body = hdnHTML.Value;

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new System.Net.Mail.MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
            }
            catch (Exception ex)
            {
                litMsg.Text = ex.Message;
            }
        }
    }

}
