using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin.Criteria
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CriteriaGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = CriteriaGridView.DataKeys[CriteriaGridView.SelectedIndex].Values["ContentId"].ToString();

            Response.Redirect(String.Format("~/criteria/edit/{0}", id));
        }
    }
}