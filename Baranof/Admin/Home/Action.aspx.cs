using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Models;
using BLL;
using MAP.Extension.StringExtensions;

namespace Admin.Home
{
    public partial class Action : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string actionMode = RouteData.Values["mode"] as string;

                if (actionMode.IsEmpty() || actionMode.Equals("add"))
                {
                    RedirectBack();
                }
                else if (actionMode.Equals("edit"))
                {
                    TitleInput.Text = ManagePageContent.GetHeadingContent("Home", "Home").ContentDetails;
                    ContentInput.Text = ManagePageContent.GetHeadingContent("Home", "Heading").ContentDetails;
                }
                else
                {
                    RedirectBack();
                }
            }
        }

        private void RedirectBack()
        {
            Response.Redirect("~/home");
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            PageContent titleContent = ManagePageContent.GetHeadingContent("Home", "Home");
            PageContent headingContent = ManagePageContent.GetHeadingContent("Home", "Heading");

            if (titleContent != null && headingContent != null)
            {
                titleContent.ContentDetails = TitleInput.Text;
                headingContent.ContentDetails = ContentInput.Text;
            }
            else
            {
                RedirectBack();
            }

            if (ManagePageContent.UpdatePageContent(titleContent) && ManagePageContent.UpdatePageContent(headingContent))
            {
                RedirectBack();
            }
            else
            {
                Response.Redirect(String.Format("~/home/edit"));
            }
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            RedirectBack();
        }
    }
}