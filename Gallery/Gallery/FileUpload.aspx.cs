using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
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
                string UUIDName = SHA1HashStringForUTF8String(fileName) + GenerateRandomNumber() + ExtensionImage();

                fplFileUpload.PostedFile.SaveAs(Server.MapPath("/ImageStorage/") + UUIDName);
                InsertGallery(UUIDName);
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
        protected string ExtensionImage()
        {
            string ext = Path.GetExtension(fplFileUpload.PostedFile.FileName);
            return ext;
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
        public static string SHA1HashStringForUTF8String(string imageName)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(imageName);

            var sha1 = SHA1.Create();
            byte[] hashBytes = sha1.ComputeHash(bytes);

            return HexStringFromBytes(hashBytes);
        }
        public static string HexStringFromBytes(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public string GenerateRandomNumber()
        {
            Random rnd = new Random();
            int number = rnd.Next(120);
            return RandomString(number);
        }
        public void InsertGallery(string UUIDName)
        {
            var context = new GalleryEntities ();

            Image image = new Image();

            image.CreateTS = DateTime.Now;
            image.BaseName = fplFileUpload.FileName;
            image.UUIDName = UUIDName;
            image.FileSize = fplFileUpload.FileBytes.Length;
            image.Rating = -1;    

            context.Image.Add(image);
            context.SaveChanges();
            int id = image.ID;
            InsertComment(id);
        }
        public void InsertComment(int id)
        {
            GalleryEntities context = new GalleryEntities();

            Comment comment = new Comment();
            

           
            comment.CreateTS = DateTime.Now;
            comment.Imgtext = txtComment.Text;
            comment.ImageSize = fplFileUpload.FileBytes.Length;
            comment.ImageID = id;
            

            context.Comment.Add(comment);
            context.SaveChanges();
        }
    }
}