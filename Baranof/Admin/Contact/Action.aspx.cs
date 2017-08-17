using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Models;
using BLL;
using MAP.Extension.StringExtensions;

namespace Admin.Contact
{
    public partial class Action : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string actionMode = RouteData.Values["mode"] as string;
                string id = RouteData.Values["id"] as string;

                if (id != null)
                {
                    if (actionMode.IsEmpty() || actionMode.Equals("add"))
                    {
                        RedirectBack();
                    }
                    else if (actionMode.Equals("edit"))
                    {
                        ContactDetailsView.DefaultMode = DetailsViewMode.Edit;
                        DAL.Models.Contact contactInfo = ManageContact.GetById(id);
                    }
                    else
                    {
                        RedirectBack();
                    }
                }
                else
                {
                    RedirectBack();
                }
            }
        }

        private void RedirectBack()
        {
            Response.Redirect("~/contact");
        }

        protected void ContactDetailsView_ItemCommand(object sender, DetailsViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Cancel", StringComparison.CurrentCultureIgnoreCase))
            {
                RedirectBack();
            }
        }

        protected void ContactDetailsView_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            if (e.AffectedRows == 0)
            {
                e.ExceptionHandled = true;
                e.KeepInEditMode = true;
            }
            else
            {
                RedirectBack();
            }
        }
    }
}