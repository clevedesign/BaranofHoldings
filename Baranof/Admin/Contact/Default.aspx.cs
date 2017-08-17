using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MAP.Helper.UploadHelper;

namespace Admin.Contact
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ContactGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = ContactGridView.DataKeys[ContactGridView.SelectedIndex].Values["ContactId"].ToString();

            Response.Redirect(String.Format("~/contact/edit/{0}", id));
        }

        //protected void UploadSummary_Click(object sender, EventArgs e)
        //{
        //    UploadResult.Text = SavePDF(SummaryUpload);
        //}

        //private string SavePDF(FileUpload f)
        //{
        //    try
        //    {
        //        if (f.HasFile)
        //        {
        //            if (!f.PostedFile.ContentType.Equals("application/pdf", StringComparison.OrdinalIgnoreCase))
        //            {
        //                return "Upload status: Only PDF file can be uploaded.";
        //            }

        //            UploadToServer ftp = new UploadToServer("ftp://198.71.226.6/pdfs", "sawmillupload", "o!bFk770");
        //            ftp.Upload("/", f.PostedFile.InputStream, f.FileName, false);

        //            return ftp.FileName + " has been successfully uploaded!";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return "The PDF failed to upload due to: " + ex.Message;
        //    }

        //    return "Please retry again!";
        //}
    }
}