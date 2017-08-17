using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin.Portfolio
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddPort_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/portfolio/add");
        }

        protected void PortGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = PortGridView.DataKeys[PortGridView.SelectedIndex].Values["PortfolioId"].ToString();

            Response.Redirect(String.Format("~/portfolio/edit/{0}", id));
        }

        protected void PortGridView_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            Response.Redirect("~/portfolio");
        }
    }
}