using System;
using Shift4Payment.Assignment.DataModelLayer.Models;
using Shift4Payment.Assignment.BusinessLayer;

namespace Shift4Payment.Assignment.PresentationLayer
{
    public partial class AddProperty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// add new property on click of add button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                PropertyModel propModel = new PropertyModel();
                propModel.Address = txtAddress.Text;
                propModel.City = txtCity.Text;
                propModel.OwnerName = txtOwnerName.Text;
                propModel.PropertyName = txtPropertyName.Text;
                propModel.State = txtState.Text;
                propModel.UserID = CommonFunction.GetProfile().UserID;
                propModel.Zip = txtZip.Text;
                var propertyBusiness = new PropertyBusiness();

                var result = propertyBusiness.SaveProperty(propModel);
                if (!result.Success)
                {
                    litMsg.Text = result.Message;
                }
                else {
                    Response.Redirect("~/ViewProperties.aspx", false);
                }

            }
            catch (Exception ex)
            {
                litMsg.Text = ex.Message;
            }
        }
    }
}