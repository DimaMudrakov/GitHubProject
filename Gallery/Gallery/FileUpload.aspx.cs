using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gallery
{
    public partial class FileUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSaveFile_Click(object sender, EventArgs e)
        {
            if(CheckFile() == true)
            {
                string fileName = Path.GetFileName(fplFileUpload.PostedFile.FileName);
                fplFileUpload.PostedFile.SaveAs(Server.MapPath("/images/") + fileName);
                lblMessage.Text = "Image is uploaded";
            }
            else
            {
                lblMessage.Text = "Image is not selected";
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("FileUpload.aspx");
        }
        protected bool CheckFile()
        {
            if (fplFileUpload.HasFile)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}