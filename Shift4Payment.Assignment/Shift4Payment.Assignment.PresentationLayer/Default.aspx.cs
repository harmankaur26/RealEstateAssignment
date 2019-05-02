using Shift4Payment.Assignment.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shift4Payment.Assignment.PresentationLayer
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// authenticate user on login button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var business = new UserBusiness();
            var result = business.LoginUser(txtUsername.Text, txtPassword.Text);
            if (!result.Success)
            {
                lblErroMsg.Visible = true;
                lblErroMsg.Text = result.Message;
            }
            else
            {
                Session["profile"] = result.Model;
                Response.Redirect("~/ViewProperties.aspx", false);
            }
        }
    }
}