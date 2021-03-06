﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Models;
using BLL;
using MAP.Extension.StringExtensions;

namespace Admin.Approach
{
    public partial class Action : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string actionMode = RouteData.Values["mode"] as string;
                string id = RouteData.Values["id"] as string;

                if (actionMode.IsEmpty() || actionMode.Equals("add"))
                {
                    RedirectToDefault();
                }
                else if (actionMode.Equals("edit"))
                {
                    if (id != null)
                    {
                        PageContent page = ManagePageContent.GetById(id);

                        if (page != null)
                        {
                            PageDetailsView.DefaultMode = DetailsViewMode.Edit;
                            ActionName.Text = "Edit " + page.ContentName;
                        }
                        else
                        {
                            RedirectToDefault();
                        }
                    }
                    else
                    {
                        RedirectToDefault();
                    }
                }
            }
        }

        private void RedirectToDefault()
        {
            Response.Redirect("~/approach");
        }

        protected void PageDetailsView_ItemCommand(object sender, DetailsViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Cancel"))
            {
                RedirectToDefault();
            }
        }

        protected void PageDetailsView_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            if (e.AffectedRows == 0)
            {
                e.ExceptionHandled = true;
                e.KeepInEditMode = true;
            }
            else
            {
                RedirectToDefault();
            }
        }
    }
}