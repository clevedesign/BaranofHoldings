using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using DAL.Models;
using BLL;
using MAP.Extension.StringExtensions;
using MAP.Helper.UploadHelper;

namespace Admin.Portfolio
{
    public partial class Action : System.Web.UI.Page
    {
        private static string _IMAGE_PATH = ConfigurationManager.AppSettings["PortLogos"];
        private IDictionary<string, string> Type_List = new Dictionary<string, string>
        {
            { "Current", "Current" },
            { "Exited", "Exited" }
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string actionMode = RouteData.Values["mode"] as string;
                string id = RouteData.Values["id"] as string;

                if (actionMode.IsEmpty() || actionMode.Equals("add"))
                {
                    PortDetailsView.DefaultMode = DetailsViewMode.Insert;
                    ActionName.Text = "Add New Portfolio";
                }
                else if (actionMode.Equals("edit"))
                {
                    if (id != null)
                    {
                        PortfolioContent port = ManagePortfolioContent.GetById(id);

                        if (port != null)
                        {
                            PortDetailsView.DefaultMode = DetailsViewMode.Edit;
                            ActionName.Text = "Edit " + port.PortfolioName;
                            DropDownList eTypeDDL = PortDetailsView.FindControl("TypeDDL") as DropDownList;
                            DropDownListBinding(eTypeDDL, Type_List);

                            if (!port.PortfolioType.IsEmpty())
                            {
                                eTypeDDL.SelectedValue = port.PortfolioType;
                            }
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
            Response.Redirect("~/portfolio");
        }

        private void DropDownListBinding(DropDownList dropDownList, IDictionary<string, string> dataSource)
        {
            dropDownList.DataSource = dataSource;
            dropDownList.DataTextField = "Value";
            dropDownList.DataValueField = "Key";
            dropDownList.DataBind();
        }

        private string SaveImage(FileUpload f)
        {
            try
            {
                if (f.HasFile)
                {
                    UploadToServer ftp = new UploadToServer("ftp://dock.arvixe.com/", "periscopeupload", "upload");
                    ftp.Upload("portfolios/", f.PostedFile.InputStream, f.FileName);

                    return ftp.FileName;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "noimg.png";
        }

        protected void PortDetailsView_ItemCommand(object sender, DetailsViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Cancel"))
            {
                RedirectToDefault();
            }
        }

        protected void PortDetailsView_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            FileUpload fImage = (FileUpload)PortDetailsView.FindControl("ImageUpload");
            DropDownList TypeDDL = PortDetailsView.FindControl("TypeDDL") as DropDownList;

            e.Values["PortfolioLogo"] = SaveImage(fImage);
            e.Values["PortfolioType"] = TypeDDL.SelectedValue;
        }

        protected void PortDetailsView_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            try
            {
                FileUpload fImage = (FileUpload)PortDetailsView.FindControl("ImageUpload");
                DropDownList TypeDDL = PortDetailsView.FindControl("TypeDDL") as DropDownList;
                string id = RouteData.Values["id"] as string;
                string oldLogo = ManagePortfolioContent.GetById(id).PortfolioLogo;

                if (!fImage.HasFile)
                {
                    e.NewValues["PortfolioLogo"] = ManagePortfolioContent.GetById(id).PortfolioLogo;
                }
                else
                {
                    if (!oldLogo.IsEmpty() && !oldLogo.Equals("noimg.png"))
                    {
                        DeleteFromServer.Delete("ftp://dock.arvixe.com:21/portfolios/" + oldLogo, "periscopeupload", "upload");
                    }

                    e.NewValues["PortfolioLogo"] = SaveImage(fImage);
                }

                e.NewValues["PortfolioType"] = TypeDDL.SelectedValue;
            }
            catch (Exception)
            {
                e.Cancel = true;
            }
        }

        protected void PortDetailsView_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            if (e.AffectedRows == 0)
            {
                e.ExceptionHandled = true;
                e.KeepInInsertMode = true;
            }
            else
            {
                RedirectToDefault();
            }
        }

        protected void PortDetailsView_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
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

        protected bool HasImage(Object image)
        {
            string img = image as string;

            if (img.IsEmpty())
            {
                return true;
            }

            return false;
        }

        protected string GetImageUrl(Object url)
        {
            string imagUrl = url as string;

            if (!imagUrl.IsEmpty())
            {
                return _IMAGE_PATH + url.ToString();
            }

            return String.Empty;
        }
    }
}