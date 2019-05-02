using Shift4Payment.Assignment.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shift4Payment.Assignment.PresentationLayer
{
    public partial class ViewProperties : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadProperties();
        }

        /// <summary>
        /// display all the properties in repeater
        /// </summary>
        private void LoadProperties()
        {
            var propertyBusiness = new PropertyBusiness();
            rptPropertyList.DataSource = propertyBusiness.GetPropertyList().Model;
            rptPropertyList.DataBind();
        }

    }
}