using Shift4Payment.Assignment.BusinessLayer;
using Shift4Payment.Assignment.DataModelLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shift4Payment.Assignment.PresentationLayer
{
    public partial class AddTenants : System.Web.UI.Page
    {
        protected string documentName = string.Empty;
        protected string documentURL = string.Empty;

        /// <summary>
        /// load property and tenant details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadPropertyDetails();
            }
        }

        /// <summary>
        /// Add tenant to the corresponding property
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = string.Concat(Guid.NewGuid(), "_", fileUploadControl.FileName);
                TenantModel tntModel = new TenantModel();
                tntModel.Firstname = txttenantFirstName.Text;
                tntModel.Lastname = txttenantLastName.Text;
                tntModel.Amount = Convert.ToDecimal(txtRentAmount.Text);
                tntModel.StartDate = Convert.ToDateTime(txtStartDate.Text);
                tntModel.EndDate = Convert.ToDateTime(txtEndDate.Text);
                tntModel.PropertyID = Convert.ToInt32(Request.QueryString["Id"]);
                tntModel.TenantID = Convert.ToInt32(hdnTenantId.Value);
                if (fileUploadControl.HasFile)
                {
                    tntModel.FileName = fileName;
                }
                else
                {
                    tntModel.FileName = hdnFileName.Value;
                }
                var tenantBusiness = new TenantBusiness();

                var result = tenantBusiness.SaveTenant(tntModel);
                if (!result.Success)
                {
                    litMsg.Text = result.Message;
                }
                else
                {
                    SaveFile(fileUploadControl, fileName);
                    LoadPropertyDetails();
                }

            }
            catch (Exception ex)
            {
                litMsg.Text = ex.Message;
            }

        }

        /// <summary>
        /// method to get the property details
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
                    txtStartDate.Text = model.StartDate.ToShortDateString();
                    txtEndDate.Text = model.EndDate.ToShortDateString();
                    hdnTenantId.Value = model.TenantID.ToString();
                    if (model.TenantID > 0)
                    {
                        btnAdd.Text = "Update Tenant";
                    }
                    if (model.FileName != null)
                    {
                        documentName = model.FileName;
                        documentURL = "documents/" + documentName;
                        btnGoogleDrive.CommandArgument = documentName;
                        hdnFileName.Value = documentName;
                    }
                }
                else
                {
                    litMsg.Text = "Invalid property Id";
                    btnAdd.Enabled = false;
                }

            }


        }
        /// <summary>
        /// method to upload file to google drive
        /// </summary>
        /// <param name="file"></param>
        /// <param name="fileName"></param>
        private void SaveFile(FileUpload file, string fileName)
        {
            try
            {
                if (file.HasFile)
                {
                    string path = string.Concat(Server.MapPath("Documents"), "//", fileName);
                    file.SaveAs(path);
                }
            }
            catch (Exception ex)
            {
                litMsg.Text = ex.Message;
            }
        }

        /// <summary>
        /// uploads file on click of a button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGoogleDrive_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (!string.IsNullOrEmpty(btn.CommandArgument))
            {
                CommonFunction.FileUpload(btn.CommandArgument);
            }
            LoadPropertyDetails();
        }
    }
}