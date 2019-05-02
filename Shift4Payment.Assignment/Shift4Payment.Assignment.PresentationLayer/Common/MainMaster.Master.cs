using Shift4Payment.Assignment.DataModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shift4Payment.Assignment.PresentationLayer.Common
{
    public partial class MainMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayUserInfo();
        }
        private void DisplayUserInfo()
        {
            var profileSession = Session["profile"];
            if (profileSession != null)
            {
                var profile = profileSession as UserModel;
                lblUserName.Text = string.Concat(profile.FirstName, " ", profile.LastName);
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}