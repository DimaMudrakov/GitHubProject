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

            if (CheckFile() == true && CheckFileType() == true && CheckFileSize() == true)
            {
                string fileName = Path.GetFileName(fplFileUpload.PostedFile.FileName);
                fplFileUpload.PostedFile.SaveAs(Server.MapPath("/images/") + fileName);
                lblMessage.Text = "Image is uploaded";
            }
            else if (CheckFile() == false)
            {
                lblMessage.Text = "Image is not selected";
            }
            else if (CheckFileType() == false)
            {
                lblMessage.Text = "The wrong type of image";
            }
            else if (CheckFileSize() == false)
            {
                lblMessage.Text = "Image size should not exceed 1 MB";
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
        protected bool CheckFileType()
        {
            string[] validFileTypes = { "png", "jpg", "jpeg", "PNG", "JPG", "JPEG" };
            string ext = Path.GetExtension(fplFileUpload.PostedFile.FileName);
            bool isValidFile = false;
            for (int i = 0; i < validFileTypes.Length; i++)
            {
                if (ext == "." + validFileTypes[i])
                {
                    isValidFile = true;
                    return true;
                }
            }
            if (!isValidFile)
            {
                return false;
            }
            else
            {
                return false;
            }

        }
        protected bool CheckFileSize()
        {
            if (fplFileUpload.FileBytes.Length <= 1048576)
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