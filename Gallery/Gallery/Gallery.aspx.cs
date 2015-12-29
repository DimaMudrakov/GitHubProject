using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity.Core.Objects;
using System.Data;
using System.Data.Entity.Validation;
using System.Text;
using System.Diagnostics;

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

            if (number == 0)
            {
                var resultFromDataBase = (from Image in context.Image
                                          join Comment in context.Comment
                                          on Image.ID equals Comment.ImageID
                                          orderby Image.CreateTS ascending
                                          select new { Image, Comment }).ToArray();

                rptImage.DataSource = resultFromDataBase;

                rptImage.DataBind();

                foreach (var result in resultFromDataBase)
                {
                    int id = result.Image.ID;
                    int rating = result.Image.Rating;
                    DisplayImageRating(id, rating, rptImage);
                }
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

                foreach (var result in resultFromDataBase)
                {
                    int id = result.Image.ID;
                    int rating = result.Image.Rating;
                    DisplayImageRating(id, rating, rptImage);
                }
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

                foreach (var result in resultFromDataBase)
                {
                    int id = result.Image.ID;
                    int rating = result.Image.Rating;
                    DisplayImageRating(id, rating, rptImage);
                }
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

                foreach (var result in resultFromDataBase)
                {
                    int id = result.Image.ID;
                    int rating = result.Image.Rating;
                    DisplayImageRating(id, rating, rptImage);
                }
            }
            else if (number == 4)
            {
                var resultFromDataBase = (from Image in context.Image
                                          join Comment in context.Comment
                                          on Image.ID equals Comment.ImageID
                                          orderby Image.Rating ascending
                                          select new { Image, Comment }).ToArray();

                rptImage.DataSource = resultFromDataBase;

                rptImage.DataBind();

                foreach (var result in resultFromDataBase)
                {
                    int id = result.Image.ID;
                    int rating = result.Image.Rating;
                    DisplayImageRating(id, rating, rptImage);
                }
            }
            else if (number == 5)
            {
                var resultFromDataBase = (from Image in context.Image
                                          join Comment in context.Comment
                                          on Image.ID equals Comment.ImageID
                                          orderby Image.Rating descending
                                          select new { Image, Comment }).ToArray();

                rptImage.DataSource = resultFromDataBase;

                rptImage.DataBind();

                foreach (var result in resultFromDataBase)
                {
                    int id = result.Image.ID;
                    int rating = result.Image.Rating;
                    DisplayImageRating(id, rating, rptImage);
                }
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

            foreach (var result in resultFromDataBase)
            {
                int id = result.Image.ID;
                int rating = result.Image.Rating;
                DisplayImageRating(id , rating, rptImage);
            }
                

        }
        public void DisplayImageRating(int id , int rating, Repeater rptImage)
        {
                foreach (RepeaterItem item in rptImage.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        var rbl = (RadioButtonList)item.FindControl("rblRating");

                        string stringID = Convert.ToString(id);
                        string stringRating = Convert.ToString(rating);

                        if (stringID == rbl.DataValueField)
                        {
                            rbl.SelectedValue = stringRating;
                        }
                    }
                }
            

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

        protected void rblRating_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioButtonList rbl = sender as RadioButtonList;

            string selectedItem = rbl.SelectedValue;
            int intRating = int.Parse(selectedItem);
            string selectedID = rbl.DataValueField;
            int inID = int.Parse(selectedID);

            UpdateImageRating(intRating, inID);

        }
                                               
        
        protected void UpdateImageRating(int intRating, int intID)
        {
            try
            {

                GalleryEntities context = this.context;

                Image image = new Image();

                image.ID = intID;
                image.Rating = intRating;
                image.BaseName = "";
                image.UUIDName = "";
                
                context.Image.Attach(image);
                var entry = context.Entry(image);
                entry.Property(i => i.Rating).IsModified = true;
                entry.Property(i => i.ID).IsModified = false;
                entry.Property(i => i.BaseName).IsModified = false;
                entry.Property(i => i.UUIDName).IsModified = false;
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Diagnostics.Trace.TraceInformation("Property: {0} Error: {1}", validationError.
                        PropertyName, validationError.ErrorMessage);
                    }
                }
            }
        }
    }

}