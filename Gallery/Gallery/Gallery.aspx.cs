using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity.Core.Objects;
using System.Data;

namespace Gallery
{
    public partial class Gallery : System.Web.UI.Page
    {
        protected GalleryEntities context = new GalleryEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {               
                DisplayImage();
            }

        }
        public void DisplayImage(int number)
        {
            GalleryEntities context = this.context;

            if(number == 0)
            {
                var resultFromDataBase = (from Image in context.Image
                                          join Comment in context.Comment
                                          on Image.ID equals Comment.ImageID
                                          orderby Image.CreateTS ascending
                                          select new { Image, Comment }).ToArray();

                rptImage.DataSource = resultFromDataBase;

                rptImage.DataBind();
            }
            else if (number == 1)
            {
                var resultFromDataBase = (from Image in context.Image
                                          join Comment in context.Comment
                                          on Image.ID equals Comment.ImageID
                                          orderby Image.CreateTS descending
                                          select new { Image, Comment }).ToArray();

                rptImage.DataSource = resultFromDataBase;

                rptImage.DataBind();
            }
            else if (number == 2)
            {
                var resultFromDataBase = (from Image in context.Image
                                          join Comment in context.Comment
                                          on Image.ID equals Comment.ImageID
                                          orderby Image.FileSize ascending
                                          select new { Image, Comment }).ToArray();

                rptImage.DataSource = resultFromDataBase;

                rptImage.DataBind();
            }
            else if (number == 3)
            {
                var resultFromDataBase = (from Image in context.Image
                                          join Comment in context.Comment
                                          on Image.ID equals Comment.ImageID
                                          orderby Image.FileSize descending
                                          select new { Image, Comment }).ToArray();

                rptImage.DataSource = resultFromDataBase;

                rptImage.DataBind();
            }

        }
        public void DisplayImage()
        {
            GalleryEntities context = this.context;


            var resultFromDataBase = (from Image in context.Image
                                      join Comment in context.Comment
                                      on Image.ID equals Comment.ImageID
                                      select new { Image, Comment }).ToArray();

            rptImage.DataSource = resultFromDataBase;

            rptImage.DataBind();
        }

        protected void rptImage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete" && e.CommandArgument.ToString() != "")
            {
                int ImageId = int.Parse(e.CommandArgument.ToString());

                DeleteComment(ImageId);
                DeleteImage(ImageId);

            }
        }
        protected void DeleteComment(int ImageId)
        {
            GalleryEntities context = this.context;

            var query = (from Comment in context.Comment
                         where Comment.ImageID == ImageId
                         select Comment);

            foreach (Comment comment in query)
            {
                context.Comment.Remove(comment);
            }

            context.SaveChanges();

        }
        protected void DeleteImage(int ImageId)
        {
            GalleryEntities context = this.context;

            var query = (from Image in context.Image
                         where Image.ID == ImageId
                         select Image);

            foreach (Image image in query)
            {
                context.Image.Remove(image);
                DeleteFile(image.UUIDName);
            }
            context.SaveChanges();
            Response.Redirect("Gallery.aspx");

        }
        protected void DeleteFile(string UUIDName)
        {
            File.Delete(Server.MapPath("/ImageStorage/") + UUIDName);
        }

        protected void btnSort_Click(object sender, EventArgs e)
        {
            int number = int.Parse(ddlSort.SelectedValue);
            DisplayImage(number);
        }
    }



}