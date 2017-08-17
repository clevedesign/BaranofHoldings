using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin.Approach
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void PageGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = PageGridView.DataKeys[PageGridView.SelectedIndex].Values["ContentId"].ToString();

            Response.Redirect(String.Format("~/approach/edit/{0}", id));
        }
    }
}