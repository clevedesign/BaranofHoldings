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

namespace Admin.Team
{
    public partial class Action : System.Web.UI.Page
    {
        private static string _IMAGE_PATH = ConfigurationManager.AppSettings["MemberPhotos"];
        private static string _VCARD_PATH = ConfigurationManager.AppSettings["MembervCards"];
        private IDictionary<string, string> Type_List = new Dictionary<string, string>
        {
            { "Team", "Team" },
            { "Borad", "Borad" }
        };

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
                        TeamDetailsView.DefaultMode = DetailsViewMode.Insert;
                        ActionName.Text = "Add New Member";
                    }
                    else if (actionMode.Equals("edit"))
                    {
                        TeamDetailsView.DefaultMode = DetailsViewMode.Edit;
                        TeamMember member = ManageTeamMember.GetById(id);
                        ActionName.Text = "Edit " + member.FirstName + " " + member.LastName;
                        DropDownList eTypeDDL = TeamDetailsView.FindControl("TypeDDL") as DropDownList;
                        DropDownListBinding(eTypeDDL, Type_List);

                        if (!member.MemberType.IsEmpty())
                        {
                            eTypeDDL.SelectedValue = member.MemberType;
                        }
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
            Response.Redirect("~/team");
        }

        private void DropDownListBinding(DropDownList dropDownList, IDictionary<string, string> dataSource)
        {
            dropDownList.DataSource = dataSource;
            dropDownList.DataTextField = "Value";
            dropDownList.DataValueField = "Key";
            dropDownList.DataBind();
        }

        private string SaveFile(FileUpload f, string path)
        {
            try
            {
                if (f.HasFile)
                {
                    UploadToServer ftp = new UploadToServer("ftp://dock.arvixe.com/", "periscopeupload", "upload");
                    ftp.Upload(path, f.PostedFile.InputStream, f.FileName);

                    return ftp.FileName;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return String.Empty;
        }

        protected void TeamDetailsView_ItemCommand(object sender, DetailsViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Cancel", StringComparison.CurrentCultureIgnoreCase))
            {
                RedirectBack();
            }
        }

        protected void TeamDetailsView_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            FileUpload fImage = (FileUpload)TeamDetailsView.FindControl("ImageUpload");
            FileUpload fvCard = (FileUpload)TeamDetailsView.FindControl("vCardUpload");
            DropDownList TypeDDL = TeamDetailsView.FindControl("TypeDDL") as DropDownList;

            e.Values["MemberOrder"] = ManageTeamMember.GetAllTeamMembersOf(TypeDDL.SelectedValue).Count + 1;
            e.Values["MemberPicture"] = SaveFile(fImage, "members/");
            e.Values["MemberVCard"] = SaveFile(fvCard, "vcards/");
            e.Values["MemberType"] = TypeDDL.SelectedValue;
        }

        protected void TeamDetailsView_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            try
            {
                FileUpload fImage = (FileUpload)TeamDetailsView.FindControl("ImageUpload");
                FileUpload fvCard = (FileUpload)TeamDetailsView.FindControl("vCardUpload");
                DropDownList TypeDDL = TeamDetailsView.FindControl("TypeDDL") as DropDownList;
                string id = RouteData.Values["id"] as string;
                string origImage = e.OldValues["MemberPicture"] as string;
                string origvCard = e.OldValues["MembervCard"] as string;

                if (fImage.HasFile)
                {
                    if (!origImage.IsEmpty() && !origImage.Contains("no_image"))
                    {
                        DeleteFromServer.Delete("ftp://dock.arvixe.com:21/members/" + origImage, "periscopeupload", "upload");
                    }

                    e.NewValues["MemberPicture"] = SaveFile(fImage, "members/");
                }
                else
                {
                    e.NewValues["MemberPicture"] = ManageTeamMember.GetById(id).MemberPicture;
                }

                if (fvCard.HasFile)
                {
                    if (!origvCard.IsEmpty())
                    {
                        DeleteFromServer.Delete("ftp://dock.arvixe.com:21/vcards/" + origImage, "periscopeupload", "upload");
                    }

                    e.NewValues["MembervCard"] = SaveFile(fvCard, "vcards/");
                }
                else
                {
                    e.NewValues["MembervCard"] = ManageTeamMember.GetById(id).MembervCard;
                }

                e.NewValues["MemberType"] = TypeDDL.SelectedValue;
            }
            catch (Exception)
            {
                e.Cancel = true;
            }
        }

        protected void TeamDetailsView_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            if (e.AffectedRows == 0)
            {
                e.ExceptionHandled = true;
                e.KeepInInsertMode = true;
            }
            else
            {
                RedirectBack();
            }
        }

        protected void TeamDetailsView_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
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

        protected bool HasFile(Object file)
        {
            string f = file as string;
            if (f.IsEmpty())
            {
                return true;
            }
            return false;
        }

        protected bool HasImage(Object image)
        {
            string img = image as string;

            if (img.IsEmpty() || img.Contains("no_image"))
            {
                return true;
            }

            return false;
        }

        protected string GetImageUrl(Object url)
        {
            string imageUrl = url as string;

            if (imageUrl.IsEmpty() || imageUrl.Contains("no_image"))
            {
                return "";
            }

            return _IMAGE_PATH + imageUrl;
        }
    }
}