using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Models;
using BLL;

namespace Admin.Home
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TitleContent.Text = ManagePageContent.GetHeadingContent("Home", "Home").ContentDetails;
            Content.Text = ManagePageContent.GetHeadingContent("Home", "Heading").ContentDetails;
        }

        protected void Edit_Content_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/home/edit");
        }
    }
}